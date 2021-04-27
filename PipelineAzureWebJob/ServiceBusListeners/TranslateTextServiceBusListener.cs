using System;
using Microsoft.Extensions.Configuration;
using PipelineAzureWebJob.Pipeline.Enums;
using PipelineAzureWebJob.Pipeline.Models;

namespace PipelineAzureWebJob.ServiceBusListeners
{
    public class TranslateTextServiceBusListener : ServiceBusListenerBase<TranslateTextPipeModel, TranslateTextPipeInQueue>
    {
        public TranslateTextServiceBusListener(IConfiguration configuration, IServiceProvider serviceProvider) 
            : base(configuration, serviceProvider)
        {
        }

        protected override string ServiceBusConnectionConfigKey => "ServiceBus";
    }
}
