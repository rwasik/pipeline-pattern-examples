using System.Threading.Tasks;
using PipelinePattern.Steps;
using PipelineWithErrorHandlingSteps.Pipeline.Model;

namespace PipelineWithErrorHandlingSteps.Pipeline.Steps
{
    public class SendEmailNotificationErrorStep : IPipeStep<TransformTextPipeModel>
    {
        public Task ExecuteAsync(TransformTextPipeModel pipeModel)
        {
            return Task.Run(() =>
            {
                // send notification email
            });
        }
    }
}
