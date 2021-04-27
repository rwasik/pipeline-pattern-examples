using PipelineAzureWebJob.Pipeline.Enums.Attributes;

namespace PipelineAzureWebJob.Pipeline.Enums
{
    public enum TranslateTextPipeOutQueue
    {
        [QueueName("approve-text-out")]
        ApproveTextQueueOut
    }
}
