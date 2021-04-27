using System.Threading.Tasks;
using PipelinePattern.Steps;
using PipelineWithErrorHandlingSteps.Pipeline.Model;

namespace PipelineWithErrorHandlingSteps.Pipeline.Steps
{
    public class AddExclamationMarkStep : IPipeStep<TransformTextPipeModel>
    {
        public Task ExecuteAsync(TransformTextPipeModel pipeModel)
        {
            return Task.Run(() => pipeModel.Text += "!");
        }
    }
}
