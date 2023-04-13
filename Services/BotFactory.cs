using Microsoft.Extensions.Logging;

using StatusDvBot.Interfaces;

namespace StatusDvBot.Services
{
    internal class BotFactory : IBotFactory
    {
        private readonly ITaskServicesProvider taskServicesProvider;
        private readonly ILoggerFactory loggerFactory;

        public BotFactory(ILoggerFactory loggerFactory, ITaskServicesProvider taskServicesProvider)
        {
            this.loggerFactory = loggerFactory;
            this.taskServicesProvider = taskServicesProvider;
        }

        ITgBot IBotFactory.Create(string token, IUpdateHandler updateHandler)
        {
            var logger = loggerFactory.CreateLogger<IUpdateHandler>();
            var loggingUpdateHandler = new LoggingUpdateHandler(updateHandler, logger);

            var taskServices = taskServicesProvider.Create(token, loggingUpdateHandler);
            var compositionTaskService = new CompositeTaskService(taskServices);

            var bot = new LimitStoppingTgBot(new TgBot(compositionTaskService));

            return bot;
        }
    }
}
