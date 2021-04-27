namespace PipelineAzureFunctions.Dtos
{
    public class TranslateTextRequest
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
    }
}
