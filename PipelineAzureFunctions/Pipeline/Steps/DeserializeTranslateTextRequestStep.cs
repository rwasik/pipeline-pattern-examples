using System.Threading.Tasks;
using Newtonsoft.Json;
using PipelineAzureFunctions.Dtos;
using PipelineAzureFunctions.Pipeline.Consts;
using PipelineAzureFunctions.Pipeline.Models;
using PipelinePattern.Steps;

namespace PipelineAzureFunctions.Pipeline.Steps
{
    public class DeserializeTranslateTextRequestStep : IInQueuePipeStep<TranslateTextPipeModel>
    {
        public string InQueueName => TranslateTextPipeInQueues.TranslateTextQueue;

        public Task ExecuteAsync(TranslateTextPipeModel pipeModel)
        {
            return Task.Run(() =>
            {
                var request = JsonConvert.DeserializeObject<TranslateTextRequest>(pipeModel.InMessage);

                pipeModel.Header = request.Header;
                pipeModel.Body = request.Body;
                pipeModel.Footer = request.Footer;
            });
        }
    }
}
