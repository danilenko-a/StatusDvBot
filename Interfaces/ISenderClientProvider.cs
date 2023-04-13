namespace StatusDvBot.Interfaces
{
    internal interface ISenderClientProvider
    {
        ISenderClient GetSenderClient(string token);
    }
}
