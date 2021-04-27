using Microsoft.Extensions.Configuration;
using PipelineAzureWebJob.Pipeline.Models;
using PipelineAzureWebJob.Pipeline.Steps;
using PipelinePattern.Factory;
using PipelinePattern.Services;

namespace PipelineAzureWebJob.Pipeline.Factories
{
    public class TranslateTextPipeFactory : IPipeFactory<TranslateTextPipeModel>
    {
        private readonly IConfiguration _configuration;
        private readonly IPipeService<TranslateTextPipeModel> _pipeService;

        public TranslateTextPipeFactory(IConfiguration configuration, IPipeService<TranslateTextPipeModel> pipeService)
        {
            _configuration = configuration;
            _pipeService = pipeService;
        }

        public IPipeServiceExecution<TranslateTextPipeModel> CreatePipe()
        {
            return _pipeService.Add(() => new DeserializeTranslateTextRequestStep())
                               .Add(() => new TranslateHeaderStep())
                               .Add(() => new TranslateBodyStep())
                               .Add(() => new TranslateFooterStep())
                               .Add(() => new SavePendingTranslation())
                               .Add(() => new PrepareApprovalTextRequestStep(_configuration))
                               .Add(() => new DeserializeApprovalTextResponseStep())
                               .Add(() => new SaveTranslatonApproval());
        }
    }
}
