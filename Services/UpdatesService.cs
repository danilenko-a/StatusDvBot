using StatusDvBot.Interfaces;
using StatusDvBot.Models;
using StatusDvBot.Telegram;

namespace StatusDvBot.Services
{
    internal class UpdatesService : IUpdatesService
    {
        public const string EMPTY_UPDATES = "{\"ok\":true,\"result\":[]}";

        private readonly IDeserializeService deserializeService;
        private readonly IRawDataClient rawDataClient;
        private long lastId = 0;

        public UpdatesService(IDeserializeService deserializeService, IRawDataClient rawDataClient)
        {
            this.deserializeService = deserializeService;
            this.rawDataClient = rawDataClient;
        }

        async Task<Result<Updates>> IUpdatesService.GetNextAsync()
        {
            var rawDataResult = await rawDataClient.GetDataAsync(lastId);
            if (rawDataResult.HasValue)
            {
                var rawData = rawDataResult.Value;
                if (!string.IsNullOrEmpty(rawData))
                {
                    if (rawData != EMPTY_UPDATES)
                    {
                        var updatesResult = deserializeService.Deserialize<Updates>(rawData);
                        if (updatesResult.HasValue)
                        {
                            var updates = updatesResult.Value;
                            if (updates.result != null)
                            {
                                lastId = updates.result[updates.result.Count - 1].update_id + 1;
                            }
                            return updates;
                        }
                    }
                }
            }

            return Result.Empty<Updates>();
        }
    }
}
