using System.Threading.Tasks;
using PipelineAzureWebJob.Pipeline.Models;
using PipelinePattern.Steps;

namespace PipelineAzureWebJob.Pipeline.Steps
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
