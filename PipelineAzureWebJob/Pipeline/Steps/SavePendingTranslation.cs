using System.Threading.Tasks;
using PipelineAzureWebJob.Pipeline.Models;
using PipelinePattern.Steps;

namespace PipelineAzureWebJob.Pipeline.Steps
{
    public class SavePendingTranslation : IPipeStep<TranslateTextPipeModel>
    {
        public Task ExecuteAsync(TranslateTextPipeModel pipeModel)
        {
            return Task.Run(() =>
            {
                // save original and translated text in db and get unique tranlation id
                pipeModel.TranslationId = 10;
            });
        }
    }
}
