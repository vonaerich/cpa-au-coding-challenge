using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CPA.Part1
{
    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                using var host = BuildHost();
                return 0;
            }
            catch (Exception)
            {
                return 1;
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
            services.AddHttpClient("ResultsClient", client =>
            {
                var baseAddress = context.Configuration.GetSection("ResultsBaseUrl")?.Value ?? string.Empty;

                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
        }
    }
}
