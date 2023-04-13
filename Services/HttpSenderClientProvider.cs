using StatusDvBot.Interfaces;

namespace StatusDvBot.Services
{
    internal class HttpSenderClientProvider : ISenderClientProvider
    {
        public HttpSenderClientProvider()
        {
        }

        ISenderClient ISenderClientProvider.GetSenderClient(string token)
        {
            return new HttpSenderClient(token);
        }
    }
}
