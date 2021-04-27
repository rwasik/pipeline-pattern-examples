using System.Threading.Tasks;
using PipelinePattern.Factory;
using PipelineWithErrorHandlingSteps.Pipeline.Model;

namespace PipelineWithErrorHandlingSteps.Services
{
    public class ModifyTextService : IModifyTextService
    {
        private readonly IPipeFactory<TransformTextPipeModel> _transformTextPipeFactory;

        public ModifyTextService(IPipeFactory<TransformTextPipeModel> transformTextPipeFactory)
        {
            _transformTextPipeFactory = transformTextPipeFactory;
        }

        public async Task<string> TransformTextAsync(string text)
        {
            var pipeModel = new TransformTextPipeModel { Text = text };

            var pipe = _transformTextPipeFactory.CreatePipe();
            await pipe.ExecuteAsync(pipeModel);

            return pipeModel.Text;
        }
    }
}
