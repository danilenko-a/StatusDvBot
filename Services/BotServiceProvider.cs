using Microsoft.Extensions.Logging;

using StatusDvBot.Interfaces;

namespace StatusDvBot.Services
{
    internal class BotServiceProvider : IBotServiceProvider
    {
        private readonly ISerializeService serializeService;
        private readonly IDeserializeService deserializeService;
        private readonly IRawDataClientProvider rawDataClientProvider;
        private readonly ISenderClientProvider senderClientProvider;
        private readonly ILoggerFactory loggerFactory;

        public BotServiceProvider(ISerializeService serializeService,
            IDeserializeService deserializeService,
            IRawDataClientProvider rawDataClientProvider,
            ISenderClientProvider senderClientProvider,
            ILoggerFactory loggerFactory)
        {
            this.serializeService = serializeService;
            this.deserializeService = deserializeService;
            this.rawDataClientProvider = rawDataClientProvider;
            this.senderClientProvider = senderClientProvider;
            this.loggerFactory = loggerFactory;
        }

        IAnswerServiceProvider IBotServiceProvider.GetAnswerServiceProvider(string token)
        {
            return new AnswerServiceProvider(serializeService, deserializeService, senderClientProvider, token);
        }

        IUpdatesService IBotServiceProvider.GetUpdateService(string token)
        {
            var rawDataClient = rawDataClientProvider.GetRawDataClient(token);
            var logger = loggerFactory.CreateLogger<IUpdatesService>();
            return  new LoggingUpdateService(new ErroringUpdatesService(new UpdatesService(deserializeService, rawDataClient)), logger);
        }
    }
}
