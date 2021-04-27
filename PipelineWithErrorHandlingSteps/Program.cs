using System;
using System.Threading.Tasks;
using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PipelinePattern.Factory;
using PipelinePattern.Services;
using PipelineWithErrorHandlingSteps.Pipeline.Factory;
using PipelineWithErrorHandlingSteps.Pipeline.Model;
using PipelineWithErrorHandlingSteps.Services;

namespace SampleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ContainerBuilder();
            var config = new ConfigurationBuilder().Build();

            var module = new ConfigurationModule(config);
            builder.RegisterModule(module);

            var services = new ServiceCollection();
            services.AddScoped<IPipeFactory<TransformTextPipeModel>, TransformTextPipeFactory>();
            services.AddScoped(typeof(IPipeService<>), typeof(PipeService<>));
            services.AddScoped<IModifyTextService, ModifyTextService>();

            builder.Populate(services);
            var container = builder.Build();

            try
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    var modifyTextService = scope.Resolve<IModifyTextService>();

                    var textToBeTransformed = "    piPeliNe pattern  ";
                    var transformedText = await modifyTextService.TransformTextAsync(textToBeTransformed);

                    Console.WriteLine(textToBeTransformed);
                    Console.WriteLine(transformedText);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}. SendEmailNotificationErrorStep was executed.");
            }

            Console.ReadLine();
        }
    }
}
