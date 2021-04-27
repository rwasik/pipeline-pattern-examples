using PipelineAzureWebJob.Pipeline.Enums.Attributes;

namespace PipelineAzureWebJob.Pipeline.Enums
{
    public enum TranslateTextPipeInQueue
    {
        [QueueName("translate-text")]
        TranslateTextQueue,
        [QueueName("approve-text-in")]
        ApproveTextQueueIn
    }
}
