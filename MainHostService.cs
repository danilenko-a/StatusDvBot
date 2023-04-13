using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

using StatusDvBot.BotAction;
using StatusDvBot.Interfaces;
using StatusDvBot.Models;

namespace StatusDvBot
{
    internal class MainHostService : IHostedService
    {
        private readonly ITgBot bot;

        public MainHostService(IOptions<TelegramBotOptions> telegramBotOptionsProvider,
            IBotFactory botFactory)
        {
            var options = telegramBotOptionsProvider.Value;
            this.bot = botFactory.Create(options.Token, new StatusDvUpdateHandler());
        }

        Task IHostedService.StartAsync(CancellationToken cancellationToken)
        {
            bot.Start();

            return Task.CompletedTask;
        }

        async Task IHostedService.StopAsync(CancellationToken cancellationToken)
        {
            await bot.StopAsync();
        }
    }
}