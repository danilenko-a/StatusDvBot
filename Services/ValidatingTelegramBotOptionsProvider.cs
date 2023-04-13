using Microsoft.Extensions.Options;

using StatusDvBot.Models;

namespace StatusDvBot.Services
{
    internal class ValidatingTelegramBotOptionsProvider : IOptions<TelegramBotOptions>
    {
        private readonly IOptions<TelegramBotOptions> telegramBotOptionsProvider;

        public ValidatingTelegramBotOptionsProvider(IOptions<TelegramBotOptions> telegramBotOptionsProvider)
        {
            this.telegramBotOptionsProvider = telegramBotOptionsProvider;
        }

        TelegramBotOptions IOptions<TelegramBotOptions>.Value
        {
            get
            {
                var value = telegramBotOptionsProvider.Value;
                if (string.IsNullOrEmpty(value.Name) || string.IsNullOrEmpty(value.Token))
                {
                    throw new ApplicationException("Значение имени и токена бота не может быть пустым");
                }
                return value;
            }
        }
    }
}
