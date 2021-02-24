using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CPA.Part1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                using var host = BuildHost();
                
                var orchestrator = host.Services.GetService<IOrchestrator>();
                await orchestrator.Start();

                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong. {e.Message}");
                Console.Read();
            }
        }

        static IHost BuildHost()
        {
            return new HostBuilder()
                .ConfigureAppConfiguration(BuildConfiguration)
                .ConfigureServices(ConfigureServices)
                .UseConsoleLifetime()
                .Build();
        }

        static void BuildConfiguration(IConfigurationBuilder builder)
        {
            builder
                .AddJsonFile("appsettings.json")
                .Build();
        }

        static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddLogging(config => 
            {
                config.AddConsole();
            });

            services.AddHttpClient("ResultsClient", client =>
            {
                var baseAddress = context.Configuration.GetSection("ResultsBaseUrl")?.Value ?? string.Empty;

                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddSingleton<IOrchestrator, Orchestrator>();
            services.AddSingleton<IExtractor, Extractor>();
            services.AddSingleton<ITransformer, Transformer>();
            services.AddSingleton<IPrinter, Printer>(_ => new Printer(Console.Out));
        }
    }
}
