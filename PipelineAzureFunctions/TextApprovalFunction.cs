using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using PipelineAzureFunctions.Pipeline.Consts;
using PipelineAzureFunctions.Services;

namespace AzureFunctions
{
    public class TextApprovalFunction
    {
        private readonly ITranslateTextService _translateTextService;
        private const string QueueName = TranslateTextPipeInQueues.ApproveTextQueueIn;

        public TextApprovalFunction(ITranslateTextService translateTextService)
        {
            _translateTextService = translateTextService;
        }

        [FunctionName("TextApproval")]
        public async Task Run([ServiceBusTrigger(QueueName, Connection = "ServiceBus")] string message)
        {
            await _translateTextService.TranslateTextAsync(message, QueueName);
        }
    }
}
