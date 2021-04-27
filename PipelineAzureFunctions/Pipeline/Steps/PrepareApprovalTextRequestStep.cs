using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PipelineAzureFunctions.Dtos;
using PipelineAzureFunctions.Pipeline.Models;
using PipelinePattern.Steps;

namespace PipelineAzureFunctions.Pipeline.Steps
{
    public class PrepareApprovalTextRequestStep : IOutQueuePipeStep<TranslateTextPipeModel>
    {
        public Task ExecuteAsync(TranslateTextPipeModel pipeModel)
        {
            return Task.Run(() =>
            {
                var request = new TranslateTextApprovalRequest
                {
                    TranslationId = pipeModel.TranslationId,

                    HeaderOriginal = pipeModel.Header,
                    BodyOriginal = pipeModel.Body,
                    FooterOriginal = pipeModel.Footer,

                    HeaderTranslated = pipeModel.HeaderTranslated,
                    BodyTranslated = pipeModel.BodyTranslated,
                    FooterTranslated = pipeModel.FooterTranslated
                };

                pipeModel.OutMessage = JsonConvert.SerializeObject(request, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            });
        }
    }
}
