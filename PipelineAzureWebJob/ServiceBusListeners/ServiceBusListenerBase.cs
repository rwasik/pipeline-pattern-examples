using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PipelineAzureWebJob.Pipeline.Enums.Attributes;
using PipelineAzureWebJob.Pipeline.Enums.Extensions;
using PipelinePattern.Factory;
using PipelinePattern.Models;

namespace PipelineAzureWebJob
{
    public abstract class ServiceBusListenerBase<TPipeModel, TInQueueEnum> : IHostedService
        where TPipeModel : IInQueuePipeModel, new()
        where TInQueueEnum : Enum 
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;
        private readonly IList<QueueClient> _queueClients;

        protected abstract string ServiceBusConnectionConfigKey { get; }

        public ServiceBusListenerBase(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _configuration = configuration;
            _serviceProvider = serviceProvider;
            _queueClients = new List<QueueClient>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            foreach(var value in Enum.GetValues(typeof(TInQueueEnum)))
            {
                var inQueueName = ((TInQueueEnum)value).GetAttribute<QueueNameAttribute>().Name;

                var queueClient = new QueueClient(_configuration[ServiceBusConnectionConfigKey], inQueueName, ReceiveMode.ReceiveAndDelete);

                var messageHandlerOptions = new MessageHandlerOptions(handler =>
                {
                    ProcessError(handler.Exception);
                    return Task.CompletedTask;
                })
                {
                    MaxConcurrentCalls = 5,
                    AutoComplete = true
                };

                queueClient.RegisterMessageHandler((message, token) => ProcessMessageAsync(message, queueClient.QueueName), messageHandlerOptions);

                _queueClients.Add(queueClient);
            }

            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            foreach (var queueClient in _queueClients)
            {
                await queueClient.CloseAsync();
            }
        }

        private async Task ProcessMessageAsync(Message message, string queueName)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var data = Encoding.UTF8.GetString(message.Body);

                var pipe = scope.ServiceProvider.GetService<IPipeFactory<TPipeModel>>().CreatePipe();
                var pipeModel = new TPipeModel { QueueName = queueName, InMessage = data };

                await pipe.ExecuteAsync(pipeModel);
            }        
        }

        private void ProcessError(Exception ex)
        {
            // process error msg
            // log error msg
        }
    }
}
