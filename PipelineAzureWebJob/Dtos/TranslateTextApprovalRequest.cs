namespace PipelineAzureWebJob.Dtos
{
    public class TranslateTextApprovalRequest
    {
        public int TranslationId { get; set; }

        public string HeaderOriginal { get; set; }
        public string BodyOriginal { get; set; }
        public string FooterOriginal { get; set; }

        public string HeaderTranslated { get; set; }
        public string BodyTranslated { get; set; }
        public string FooterTranslated { get; set; }
    }
}
