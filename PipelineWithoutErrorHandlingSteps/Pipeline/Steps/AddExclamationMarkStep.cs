using System.Threading.Tasks;
using PipelinePattern.Steps;
using PipelineWithoutErrorHandlingSteps.Pipeline.Model;

namespace PipelineWithoutErrorHandlingSteps.Pipeline.Steps
{
    public class AddExclamationMarkStep : IPipeStep<TransformTextPipeModel>
    {
        public Task ExecuteAsync(TransformTextPipeModel pipeModel)
        {
            return Task.Run(() => pipeModel.Text += "!");
        }
    }
}
