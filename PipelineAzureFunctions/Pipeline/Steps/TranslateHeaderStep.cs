using System.Threading.Tasks;
using PipelineAzureFunctions.Pipeline.Models;
using PipelinePattern.Steps;

namespace PipelineAzureFunctions.Pipeline.Steps
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
