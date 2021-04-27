using PipelineAzureFunctions.Pipeline.Models;
using PipelineAzureFunctions.Pipeline.Steps;
using PipelinePattern.Factory;
using PipelinePattern.Services;

namespace PipelineAzureFunctions.Pipeline.Factories
{
    public class TranslateTextPipeFactory : IPipeFactory<TranslateTextPipeModel>
    {
        private readonly IPipeService<TranslateTextPipeModel> _pipeService;

        public TranslateTextPipeFactory(IPipeService<TranslateTextPipeModel> pipeService)
        {
            _pipeService = pipeService;
        }

        public IPipeServiceExecution<TranslateTextPipeModel> CreatePipe()
        {
            return _pipeService.Add(() => new DeserializeTranslateTextRequestStep())
                               .Add(() => new TranslateHeaderStep())
                               .Add(() => new TranslateBodyStep())
                               .Add(() => new TranslateFooterStep())
                               .Add(() => new SavePendingTranslation())
                               .Add(() => new PrepareApprovalTextRequestStep())
                               .Add(() => new DeserializeApprovalTextResponseStep())
                               .Add(() => new SaveTranslatonApproval());
        }
    }
}
