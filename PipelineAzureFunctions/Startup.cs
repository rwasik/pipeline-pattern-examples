using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using PipelineAzureFunctions.Pipeline.Factories;
using PipelineAzureFunctions.Pipeline.Models;
using PipelineAzureFunctions.Services;
using PipelinePattern.Factory;
using PipelinePattern.Services;

[assembly: FunctionsStartup(typeof(PipelineAzureFunctions.Startup))]
namespace PipelineAzureFunctions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IPipeFactory<TranslateTextPipeModel>, TranslateTextPipeFactory>();
            builder.Services.AddScoped(typeof(IPipeService<>), typeof(QueuePipeService<>));
            builder.Services.AddScoped<ITranslateTextService, TranslateTextService>();
        }
    }
}
