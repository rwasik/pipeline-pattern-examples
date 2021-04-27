using System.Threading.Tasks;
using Newtonsoft.Json;
using PipelineAzureWebJob.Dtos;
using PipelineAzureWebJob.Pipeline.Enums;
using PipelineAzureWebJob.Pipeline.Enums.Attributes;
using PipelineAzureWebJob.Pipeline.Enums.Extensions;
using PipelineAzureWebJob.Pipeline.Models;
using PipelinePattern.Steps;

namespace PipelineAzureWebJob.Pipeline.Steps
{
    public class DeserializeTranslateTextRequestStep : IInQueuePipeStep<TranslateTextPipeModel>
    {
        public string InQueueName => TranslateTextPipeInQueue.TranslateTextQueue.GetAttribute<QueueNameAttribute>().Name;

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
