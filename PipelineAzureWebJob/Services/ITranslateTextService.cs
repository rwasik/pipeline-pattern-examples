using System.Threading.Tasks;
using PipelineAzureWebJob.Pipeline.Models;

namespace PipelineAzureWebJob.Services
{
    public interface ITranslateTextService
    {
        Task<TranslateTextPipeModel> TranslateTextAsync(string message, string queueName);
    }
}
