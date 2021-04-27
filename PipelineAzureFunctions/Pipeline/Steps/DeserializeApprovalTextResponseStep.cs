using System.Threading.Tasks;
using Newtonsoft.Json;
using PipelineAzureFunctions.Dtos;
using PipelineAzureFunctions.Pipeline.Consts;
using PipelineAzureFunctions.Pipeline.Models;
using PipelinePattern.Steps;

namespace PipelineAzureFunctions.Pipeline.Steps
{
    public class DeserializeApprovalTextResponseStep : IInQueuePipeStep<TranslateTextPipeModel>
    {
        public string InQueueName => TranslateTextPipeInQueues.ApproveTextQueueIn;

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
