namespace StatusDvBot.Interfaces
{
    internal interface ITaskService
    {
        void Start();

        Task StopAsync();
    }
}
