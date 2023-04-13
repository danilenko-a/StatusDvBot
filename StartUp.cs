using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using StatusDvBot.Interfaces;
using StatusDvBot.Models;
using StatusDvBot.Services;

namespace StatusDvBot
{
    internal class StartUp
    {
        public void RegisterServices(IServiceCollection services)
        {
            services
                .AddSingleton<IOptions<TelegramBotOptions>>(provider =>
                {
                    var configuration = provider.GetRequiredService<IConfiguration>();
                    return new ValidatingTelegramBotOptionsProvider(new TelegramBotOptionsProvider(configuration));
                })
                .AddSingleton<IBotFactory, BotFactory>()
                .AddSingleton<IUpdatesQueueProvider, UpdatesQueueProvider>()
                .AddSingleton<ITaskServicesProvider, TaskServicesProvider>()
                .AddSingleton<IBotServiceProvider, BotServiceProvider>()
                .AddSingleton<IHandleUpdatesTaskServiceFactory, HandleUpdatesTaskServiceFactory>()
                .AddSingleton<IReceiptUpdatesTaskServiceFactory, ReceiptUpdatesTaskServiceFactory>()
                .AddSingleton<IOptions<BotCoreOptions>, BotCoreOptionsProvider>()
                .AddSingleton<IRawDataClientProvider, HttpRawDataClientProvider>()
                .AddSingleton<ISenderClientProvider, HttpSenderClientProvider>()
                .AddSingleton<ISerializeService, JsonSerializeService>()
                .AddSingleton<IDeserializeService, JsonDeserializeService>()
            ;
        }
    }
}