using StatusDvBot.Interfaces;

namespace StatusDvBot.Services
{
    internal class AnswerServiceProvider : IAnswerServiceProvider
    {
        private readonly ISerializeService serializeService;
        private readonly IDeserializeService deserializeService;
        private readonly ISenderClientProvider senderClientProvider;
        private readonly string token;

        public AnswerServiceProvider(ISerializeService serializeService, 
            IDeserializeService deserializeService, 
            ISenderClientProvider senderClientProvider, 
            string token)
        {
            this.serializeService = serializeService;
            this.deserializeService = deserializeService;
            this.senderClientProvider = senderClientProvider;
            this.token = token;
        }

        IAnswerService IAnswerServiceProvider.Get()
        {
            var senderClient = senderClientProvider.GetSenderClient(token);
            return new AnswerService(serializeService, senderClient, deserializeService);
        }
    }
}
