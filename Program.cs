using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Serilog;

using StatusDvBot.Extensions;

namespace StatusDvBot
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().ConfigureFromSettings().Build();
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

            try
            {
                await Host.CreateDefaultBuilder(args)
                    .UseConsoleLifetime()
                    .ConfigureHostConfiguration(configuration => configuration.AddCommandLine(args))
                    .ConfigureAppConfiguration((context, configuration) => configuration.ConfigureFromSettings())
                    .ConfigureServices((context, services) =>
                    {
                        services.AddHostedService<MainHostService>()
                            .UseStartUp<StartUp>();
                    })
                    .UseSerilog((context, services, configuration) => configuration.ReadFrom.Configuration(context.Configuration))
                    .Build()
                    .RunAsync();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"Failed to start StatusDvBot");
                await Log.CloseAndFlushAsync();
                throw;
            }
        }
    }
}