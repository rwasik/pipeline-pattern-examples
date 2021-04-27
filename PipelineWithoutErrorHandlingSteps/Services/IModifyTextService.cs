using System.Threading.Tasks;

namespace PipelineWithoutErrorHandlingSteps.Services
{
    public interface IModifyTextService
    {
        Task<string> TransformTextAsync(string text);
    }
}
