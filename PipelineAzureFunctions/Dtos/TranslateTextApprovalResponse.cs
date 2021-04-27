namespace PipelineAzureFunctions.Dtos
{
    public class TranslateTextApprovalResponse
    {
        public int TranslationId { get; set; }
        public bool IsApproved { get; set; }
        public string RejectionReason { get; set; }
    }
}
