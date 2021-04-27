using Microsoft.Extensions.Configuration;
using PipelineAzureWebJob.Dtos;
using PipelineAzureWebJob.Pipeline.Enums;
using PipelineAzureWebJob.Pipeline.Enums.Attributes;
using PipelineAzureWebJob.Pipeline.Enums.Extensions;
using PipelineAzureWebJob.Pipeline.Models;

namespace PipelineAzureWebJob.Pipeline.Steps
{
    public class PrepareApprovalTextRequestStep : OutServiceBusPipeStep<TranslateTextPipeModel, TranslateTextApprovalRequest>
    {
        public PrepareApprovalTextRequestStep(IConfiguration configuration) 
            : base(configuration)
        {
        }

        public override string OutQueueName => TranslateTextPipeOutQueue.ApproveTextQueueOut.GetAttribute<QueueNameAttribute>().Name;

        public override string ServiceBusConnectionConfigKey => "ServiceBus";

        public override TranslateTextApprovalRequest CreateOutQueueMessage(TranslateTextPipeModel pipeModel)
        {
            return new TranslateTextApprovalRequest
            {
                TranslationId = pipeModel.TranslationId,

                HeaderOriginal = pipeModel.Header,
                BodyOriginal = pipeModel.Body,
                FooterOriginal = pipeModel.Footer,

                HeaderTranslated = pipeModel.HeaderTranslated,
                BodyTranslated = pipeModel.BodyTranslated,
                FooterTranslated = pipeModel.FooterTranslated
            };
        }
    }
}
