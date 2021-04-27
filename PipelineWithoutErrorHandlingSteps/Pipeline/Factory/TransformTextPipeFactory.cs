using PipelinePattern.Factory;
using PipelinePattern.Services;
using PipelineWithoutErrorHandlingSteps.Pipeline.Model;
using PipelineWithoutErrorHandlingSteps.Pipeline.Steps;

namespace PipelineWithoutErrorHandlingSteps.Pipeline.Factory
{
    public class TransformTextPipeFactory : IPipeFactory<TransformTextPipeModel>
    {
        private readonly IPipeService<TransformTextPipeModel> _pipeService;

        public TransformTextPipeFactory(IPipeService<TransformTextPipeModel> pipeService)
        {
            _pipeService = pipeService;
        }

        public IPipeServiceExecution<TransformTextPipeModel> CreatePipe()
        {
            return _pipeService.Add(() => new TrimTextStep())
                               .Add(() => new ToUppercaseStep())
                               .Add(() => new AddExclamationMarkStep());
        }
    }
}
