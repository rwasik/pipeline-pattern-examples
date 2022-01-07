using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PipelinePattern.Models;
using PipelinePattern.Steps;

namespace PipelineAzureWebJob.Pipeline.Steps
{
    public abstract class OutServiceBusPipeStep<TPipeModel, TOutQueueModel> : IOutQueuePipeStep<TPipeModel> where TPipeModel : IInQueuePipeModel
    {
        private readonly string _serviceBusConnectionString;
        private readonly ReceiveMode _receiveMode;
        private readonly RetryPolicy _retryPolicy;

        public OutServiceBusPipeStep(IConfiguration configration, ReceiveMode receiveMode = ReceiveMode.PeekLock, RetryPolicy retryPolicy = null)
        {
            _serviceBusConnectionString = configration[ServiceBusConnectionConfigKey];
            _receiveMode = receiveMode;
            _retryPolicy = retryPolicy;
        }

        public abstract string ServiceBusConnectionConfigKey { get; }
        public abstract string OutQueueName { get; }
        public abstract TOutQueueModel CreateOutQueueMessage(TPipeModel pipeModel);

        public async Task ExecuteAsync(TPipeModel pipeModel)
        {
            TOutQueueModel outQueueModel = CreateOutQueueMessage(pipeModel);

            var queueClient = new QueueClient(_serviceBusConnectionString, OutQueueName, _receiveMode, _retryPolicy);

            string json = JsonConvert.SerializeObject(outQueueModel);
            Message message = new Message(Encoding.UTF8.GetBytes(json));

            try
            {
                await queueClient.SendAsync(message);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }
    }
}
