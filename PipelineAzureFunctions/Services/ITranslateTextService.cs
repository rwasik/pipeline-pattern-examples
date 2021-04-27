using System.Threading.Tasks;
using PipelineAzureFunctions.Pipeline.Models;

namespace PipelineAzureFunctions.Services
{
    public interface ITranslateTextService
    {
        Task<TranslateTextPipeModel> TranslateTextAsync(string message, string queueName);
    }
}
