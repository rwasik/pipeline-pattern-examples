using System.Threading.Tasks;
using PipelineAzureFunctions.Pipeline.Models;
using PipelinePattern.Steps;

namespace PipelineAzureFunctions.Pipeline.Steps
{
    public class SavePendingTranslation : IPipeStep<TranslateTextPipeModel>
    {
        public Task ExecuteAsync(TranslateTextPipeModel pipeModel)
        {
            return Task.Run(() =>
            {
                // save original and translated text in db and get unique translation id
                pipeModel.TranslationId = 10;
            });
        }
    }
}
