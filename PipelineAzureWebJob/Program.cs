using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PipelineAzureWebJob.Pipeline.Factories;
using PipelineAzureWebJob.Pipeline.Models;
using PipelineAzureWebJob.ServiceBusListeners;
using PipelineAzureWebJob.Services;
using PipelinePattern.Factory;
using PipelinePattern.Services;

namespace PipelineAzureWebJob
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new HostBuilder();

            builder.ConfigureAppConfiguration(b =>
            {
                b.SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables();

                b.Build();
            });

            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddServiceBus();
                b.AddTimers();
            });

            builder.ConfigureServices((context, services) =>
            {
                services.AddScoped<IPipeFactory<TranslateTextPipeModel>, TranslateTextPipeFactory>();
                services.AddScoped(typeof(IPipeService<>), typeof(QueuePipeService<>));
                services.AddScoped<ITranslateTextService, TranslateTextService>();

                services.AddHostedService<TranslateTextServiceBusListener>();
            });

            var host = builder.Build();
            using (host)
            {
                host.Run();
            }
        }
    }
}