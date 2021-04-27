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
    public class DeserializeApprovalTextResponseStep : IInQueuePipeStep<TranslateTextPipeModel>
    {
        public string InQueueName => TranslateTextPipeInQueue.ApproveTextQueueIn.GetAttribute<QueueNameAttribute>().Name;

        public Task ExecuteAsync(TranslateTextPipeModel pipeModel)
        {
            return Task.Run(() =>
            {
                var response = JsonConvert.DeserializeObject<TranslateTextApprovalResponse>(pipeModel.InMessage);

                pipeModel.TranslationId = response.TranslationId;
                pipeModel.IsApproved = response.IsApproved;
                pipeModel.RejectionReason = response.RejectionReason;
            });
        }
    }
}
