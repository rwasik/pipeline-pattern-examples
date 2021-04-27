using System.Threading.Tasks;
using PipelineAzureWebJob.Pipeline.Models;
using PipelinePattern.Factory;

namespace PipelineAzureWebJob.Services
{
    public class TranslateTextService : ITranslateTextService
    {
        private readonly IPipeFactory<TranslateTextPipeModel> _translateTextPipeFactory;

        public TranslateTextService(IPipeFactory<TranslateTextPipeModel> translateTextPipeFactory)
        {
            _translateTextPipeFactory = translateTextPipeFactory;
        }

        public async Task<TranslateTextPipeModel> TranslateTextAsync(string message, string queueName)
        {
            var pipe = _translateTextPipeFactory.CreatePipe();

            var pipeModel = new TranslateTextPipeModel
            {
                QueueName = queueName,
                InMessage = message
            };

            await pipe.ExecuteAsync(pipeModel);

            return pipeModel;
        }
    }
}
