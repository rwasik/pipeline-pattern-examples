using System.Threading.Tasks;

namespace PipelineWithErrorHandlingSteps.Services
{
    public interface IModifyTextService
    {
        Task<string> TransformTextAsync(string text);
    }
}
