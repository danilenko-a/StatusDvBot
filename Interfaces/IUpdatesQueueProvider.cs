namespace StatusDvBot.Interfaces
{
    internal interface IUpdatesQueueProvider
    {
        IUpdatesQueue Create();
    }
}
