using StatusDvBot.Interfaces;

namespace StatusDvBot.Services
{
    internal class HandleUpdatesTaskServiceFactory : IHandleUpdatesTaskServiceFactory
    {
        public HandleUpdatesTaskServiceFactory()
        {
            
        }

        ITaskService IHandleUpdatesTaskServiceFactory.Create(IAnswerServiceProvider answerServiceProvider, IUpdatesQueue updatesQueue, 
            IUpdateHandler updateHandler, CancellationToken token)
        {
            return new TaskService(new Task(async () =>
            {
                var answerService = answerServiceProvider.Get();

                while (!token.IsCancellationRequested)
                {
                    while (true)
                    {
                        var updateResult = updatesQueue.Dequeue();
                        if (!updateResult.HasValue)
                        {
                            break;
                        }

                        await updateHandler.Handle(updateResult.Value, answerService);
                    }

                    await Task.Delay(TimeSpan.FromMilliseconds(100));
                }
            }));
        }
    }
}
