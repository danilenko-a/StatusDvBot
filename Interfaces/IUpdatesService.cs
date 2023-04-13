using StatusDvBot.Models;
using StatusDvBot.Telegram;

namespace StatusDvBot.Interfaces
{
    internal interface IUpdatesService
    {
        Task<Result<Updates>> GetNextAsync();
    }
}
