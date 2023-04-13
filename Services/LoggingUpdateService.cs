using Microsoft.Extensions.Logging;

using StatusDvBot.Interfaces;
using StatusDvBot.Models;
using StatusDvBot.Telegram;

namespace StatusDvBot.Services
{
    internal class LoggingUpdateService : IUpdatesService
    {
        private readonly IUpdatesService updatesService;
        private readonly ILogger<IUpdatesService> logger;

        public LoggingUpdateService(IUpdatesService updatesService, ILogger<IUpdatesService> logger)
        {
            this.updatesService = updatesService;
            this.logger = logger;
        }

        async Task<Result<Updates>> IUpdatesService.GetNextAsync()
        {
            try
            {
                return await updatesService.GetNextAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ошибка получения обновлений");
                return Result.Empty<Updates>();
            }
        }
    }
}
