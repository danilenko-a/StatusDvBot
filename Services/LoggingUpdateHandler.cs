using Microsoft.Extensions.Logging;
using StatusDvBot.Interfaces;
using StatusDvBot.Telegram;

namespace StatusDvBot.Services
{
    internal class LoggingUpdateHandler : IUpdateHandler
    {
        private readonly IUpdateHandler updateHandler;
        private readonly ILogger<IUpdateHandler> logger;

        public LoggingUpdateHandler(IUpdateHandler updateHandler, ILogger<IUpdateHandler> logger)
        {
            this.updateHandler = updateHandler;
            this.logger = logger;
        }

        async Task IUpdateHandler.Handle(Update update, IAnswerService botSender)
        {
            try
            {
                await updateHandler.Handle(update, botSender);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ошибка обработки сообщения");
            }
        }
    }
}
