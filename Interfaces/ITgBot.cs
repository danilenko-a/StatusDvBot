namespace StatusDvBot.Interfaces
{
    internal interface ITgBot
    {
        void Start();

        Task StopAsync();
    }
}
