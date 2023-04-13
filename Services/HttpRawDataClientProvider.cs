using StatusDvBot.Interfaces;

namespace StatusDvBot.Services
{
    internal class HttpRawDataClientProvider : IRawDataClientProvider
    {
        public HttpRawDataClientProvider()
        {
            
        }

        IRawDataClient IRawDataClientProvider.GetRawDataClient(string token)
        {
            return new HttpRawDataClient(token);
        }
    }
}
