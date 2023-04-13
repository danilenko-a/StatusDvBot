using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

using StatusDvBot.Models;

namespace StatusDvBot.Services
{
    internal class TelegramBotOptionsProvider : IOptions<TelegramBotOptions>
    {
        public const string SECTION_NAME = "TelegramBot";

        private readonly IConfiguration configuration;
        private TelegramBotOptions? options;

        public TelegramBotOptionsProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        TelegramBotOptions IOptions<TelegramBotOptions>.Value 
        {
            get 
            {
                if (options == null)
                {
                    var section = configuration.GetRequiredSection(SECTION_NAME);

                    var model = new TelegramBotModel();
                    section.Bind(model);

                    options = new TelegramBotOptions(model.BotName, model.BotToken);
                }

                return options;
            }
        }

        private class TelegramBotModel
        {
            public string? BotName { get; set; }

            public string? BotToken { get; set; }
        }
    }
}
