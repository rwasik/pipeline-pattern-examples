using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using PipelineAzureFunctions.Pipeline.Consts;
using PipelineAzureFunctions.Services;

namespace AzureFunctions
{
    public class TranslateTextFunction
    {
        private readonly ITranslateTextService _translateTextService;
        private const string QueueName = TranslateTextPipeInQueues.TranslateTextQueue;

        public TranslateTextFunction(ITranslateTextService translateTextService)
        {
            _translateTextService = translateTextService;
        }

        [FunctionName("TranslateText")]
        [return: ServiceBus(TranslateTextPipeOutQueues.ApproveTextQueueOut, Connection = "ServiceBus")]
        public async Task<string> Run([ServiceBusTrigger(QueueName, Connection = "ServiceBus")] string message)
        {
            var output = await _translateTextService.TranslateTextAsync(message, QueueName);

            return output.OutMessage;
        }
    }
}
