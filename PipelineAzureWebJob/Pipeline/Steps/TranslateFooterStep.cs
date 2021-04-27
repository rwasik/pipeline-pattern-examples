using System.Threading.Tasks;
using PipelineAzureWebJob.Pipeline.Models;
using PipelinePattern.Steps;

namespace PipelineAzureWebJob.Pipeline.Steps
{
    public class TranslateFooterStep : IPipeStep<TranslateTextPipeModel>
    {
        public Task ExecuteAsync(TranslateTextPipeModel pipeModel)
        {
            return Task.Run(() => pipeModel.FooterTranslated = TranslateFooter(pipeModel.Footer));
        }

        private string TranslateFooter(string footer)
        {
            return "Este es el cuerpo del pie de página";
        }
    }
}
