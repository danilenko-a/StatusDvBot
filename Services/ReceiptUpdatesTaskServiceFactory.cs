using StatusDvBot.Interfaces;

namespace StatusDvBot.Services
{
    internal class ReceiptUpdatesTaskServiceFactory : IReceiptUpdatesTaskServiceFactory
    {
        public ReceiptUpdatesTaskServiceFactory()
        {
            
        }

        ITaskService IReceiptUpdatesTaskServiceFactory.Create(IUpdatesService updatesService, IUpdatesQueue updatesQueue, CancellationToken token)
        {
            return new TaskService(new Task(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    var updatesResult = await updatesService.GetNextAsync();

                    if (updatesResult.HasValue)
                    {
                        if (updatesResult.Value.result?.Count > 0)
                        {
                            var updates = updatesResult.Value;
                            for (int i = 0; i < updates.result.Count; i++)
                                updatesQueue.Enqueue(updates.result[i]);
                        }
                    }

                    await Task.Delay(TimeSpan.FromMilliseconds(100));
                }
            }));
        }
    }
}
