using Microsoft.Extensions.Logging;

using StatusDvBot.Interfaces;
using StatusDvBot.Models;
using StatusDvBot.Telegram;

namespace StatusDvBot.Services
{
    internal class ErroringUpdatesService : IUpdatesService
    {
        private readonly IUpdatesService updatesService;

        public ErroringUpdatesService(IUpdatesService updatesService)
        {
            this.updatesService = updatesService;
        }

        async Task<Result<Updates>> IUpdatesService.GetNextAsync()
        {
            var updatesResult = await updatesService.GetNextAsync();
            if (updatesResult.HasValue)
            {
                var updates = updatesResult.Value;
                if (!updates.ok)
                {
                    throw new ApplicationException($"{updates.error_code} - {updates.description}");
                }
            }
            return updatesResult;
        }
    }
}
