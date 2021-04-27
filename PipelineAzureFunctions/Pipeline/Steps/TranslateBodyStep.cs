using System.Threading.Tasks;
using PipelineAzureFunctions.Pipeline.Models;
using PipelinePattern.Steps;

namespace PipelineAzureFunctions.Pipeline.Steps
{
    public class TranslateBodyStep : IPipeStep<TranslateTextPipeModel>
    {
        public Task ExecuteAsync(TranslateTextPipeModel pipeModel)
        {
            return Task.Run(() => pipeModel.BodyTranslated = TranslateBody(pipeModel.Body));
        }

        private string TranslateBody(string body)
        {
            return "Este es el cuerpo del texto";
        }
    }
}
