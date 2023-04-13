namespace StatusDvBot.Interfaces
{
    internal interface IReceiptUpdatesTaskServiceFactory
    {
        ITaskService Create(IUpdatesService updatesService, IUpdatesQueue updatesQueue, CancellationToken token);
    }
}
