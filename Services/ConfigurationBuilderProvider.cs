using Microsoft.Extensions.Configuration;

namespace StatusDvBot.Services
{
    internal class ConfigurationBuilderProvider
    {
        public ConfigurationBuilderProvider()
        {

        }

        public IConfigurationBuilder Get(IConfigurationBuilder configurationBuilder, string? currentRootPath = null)
        {
            return TrySetBasePath(configurationBuilder, currentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
        }

        private IConfigurationBuilder TrySetBasePath(IConfigurationBuilder configurationBuilder, string? currentRootPath)
        {
            return string.IsNullOrEmpty(currentRootPath) ? configurationBuilder : configurationBuilder.SetBasePath(currentRootPath);
        }
    }
}
