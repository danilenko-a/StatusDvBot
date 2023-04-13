using Microsoft.Extensions.Configuration;

using StatusDvBot.Services;

namespace StatusDvBot.Extensions
{
    internal static class ConfigurationBuilderExtensions
    {
        private static readonly ConfigurationBuilderProvider configurationBuilderProvider = new ConfigurationBuilderProvider();

        public static IConfigurationBuilder ConfigureFromSettings(this IConfigurationBuilder configurationBuilder, string? currentRootPath = null)
        {
            return configurationBuilderProvider.Get(configurationBuilder, currentRootPath);
        }
    }
}
