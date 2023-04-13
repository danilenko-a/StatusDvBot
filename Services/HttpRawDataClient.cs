using StatusDvBot.Interfaces;
using StatusDvBot.Models;

namespace StatusDvBot.Services
{
    internal class HttpRawDataClient : IRawDataClient, IDisposable
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string token;

        public HttpRawDataClient(string token)
        {
            this.token = token;
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }

        async Task<Result<string>> IRawDataClient.GetDataAsync(long lastId)
        {
            var uri = $"https://api.telegram.org/bot{token}/getUpdates" + (lastId > 0 ? "?offset=" + lastId.ToString() : "");
            using var response = await httpClient.GetAsync(uri);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
