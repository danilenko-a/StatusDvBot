using StatusDvBot.Models;

namespace StatusDvBot.Interfaces
{
    internal interface ISenderClient
    {
        Task<Result<string>> SendStringAsync(string content, string methodName);

        Task<Result<string>> SendFileAsync(Stream stream, string fileName, string methodName, long chatId);
    }
}
