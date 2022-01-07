using PipelinePattern.Models;

namespace PipelineAzureWebJob.Pipeline.Models
{
    public class TranslateTextPipeModel : IInQueuePipeModel
    {
        // pipe input
        public string QueueName { get; set; }
        public string InMessage { get; set; }

        // pipe internal
        public int TranslationId { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }

        public string HeaderTranslated { get; set; }
        public string BodyTranslated { get; set; }
        public string FooterTranslated { get; set; }

        public bool? IsApproved { get; set; }
        public string RejectionReason { get; set; }
    }
}
