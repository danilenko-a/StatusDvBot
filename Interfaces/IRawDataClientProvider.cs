namespace StatusDvBot.Interfaces
{
    internal interface IRawDataClientProvider
    {
        IRawDataClient GetRawDataClient(string token);
    }
}
