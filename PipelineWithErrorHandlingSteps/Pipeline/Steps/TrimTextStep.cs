using System;
using System.Threading.Tasks;
using PipelinePattern.Steps;
using PipelineWithErrorHandlingSteps.Pipeline.Model;

namespace PipelineWithErrorHandlingSteps.Pipeline.Steps
{
    public class TrimTextStep : IPipeStep<TransformTextPipeModel>
    {
        public Task ExecuteAsync(TransformTextPipeModel pipeModel)
        {
            return Task.Run(() => throw new Exception("Trim text caused error"));
        }
    }
}
