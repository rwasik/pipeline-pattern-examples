using System.Threading.Tasks;
using PipelineAzureWebJob.Pipeline.Models;
using PipelinePattern.Steps;

namespace PipelineAzureWebJob.Pipeline.Steps
{
    public class TranslateHeaderStep : IPipeStep<TranslateTextPipeModel>
    {
        public Task ExecuteAsync(TranslateTextPipeModel pipeModel)
        {
            return Task.Run(() => pipeModel.HeaderTranslated = TranslateHeader(pipeModel.Header));
        }

        private string TranslateHeader(string header)
        {
            return "Este es el encabezado";
        }
    }
}
