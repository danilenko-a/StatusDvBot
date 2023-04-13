namespace StatusDvBot.Interfaces
{
    internal interface IHandleUpdatesTaskServiceFactory
    {
        ITaskService Create(IAnswerServiceProvider answerServiceProvider, IUpdatesQueue updatesQueue, IUpdateHandler updateHandler, 
            CancellationToken token);
    }
}
