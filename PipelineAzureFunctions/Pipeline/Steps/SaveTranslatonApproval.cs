using System.Threading.Tasks;
using PipelineAzureFunctions.Pipeline.Models;
using PipelinePattern.Steps;

namespace PipelineAzureFunctions.Pipeline.Steps
{
    public class SaveTranslatonApproval : IPipeStep<TranslateTextPipeModel>
    {
        public Task ExecuteAsync(TranslateTextPipeModel pipeModel)
        {
            return Task.Run(() =>
            {
                // save final translation approval
            });
        }
    }
}
