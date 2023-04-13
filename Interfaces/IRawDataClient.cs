using StatusDvBot.Models;

namespace StatusDvBot.Interfaces
{
    internal interface IRawDataClient
    {
        Task<Result<string>> GetDataAsync(long lastId);
    }
}
