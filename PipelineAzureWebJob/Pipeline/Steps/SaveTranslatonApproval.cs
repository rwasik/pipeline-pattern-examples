using System.Threading.Tasks;
using PipelineAzureWebJob.Pipeline.Models;
using PipelinePattern.Steps;

namespace PipelineAzureWebJob.Pipeline.Steps
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
