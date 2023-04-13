using Microsoft.Extensions.Options;

using StatusDvBot.Interfaces;
using StatusDvBot.Models;

namespace StatusDvBot.Services
{
    internal class TaskServicesProvider : ITaskServicesProvider
    {
        private readonly IBotServiceProvider botServiceProvider;
        private readonly IUpdatesQueueProvider updatesQueueProvider;
        private readonly IOptions<BotCoreOptions> botCoreOptionsProvider;
        private readonly IHandleUpdatesTaskServiceFactory handleUpdatesLoopServiceTaskFactory;
        private readonly IReceiptUpdatesTaskServiceFactory receiptUpdatesLoopServiceTaskFactory;

        public TaskServicesProvider(IBotServiceProvider botServiceProvider, 
            IUpdatesQueueProvider updatesQueueProvider,
            IOptions<BotCoreOptions> botCoreOptionsProvider, 
            IHandleUpdatesTaskServiceFactory handleUpdatesLoopServiceTaskFactory, 
            IReceiptUpdatesTaskServiceFactory receiptUpdatesLoopServiceTaskFactory)
        {
            this.botServiceProvider = botServiceProvider;
            this.updatesQueueProvider = updatesQueueProvider;
            this.botCoreOptionsProvider = botCoreOptionsProvider;
            this.handleUpdatesLoopServiceTaskFactory = handleUpdatesLoopServiceTaskFactory;
            this.receiptUpdatesLoopServiceTaskFactory = receiptUpdatesLoopServiceTaskFactory;
        }

        IEnumerable<ITaskService> ITaskServicesProvider.Create(string token, IUpdateHandler updateHandler)
        {
            var updatesQueue = updatesQueueProvider.Create();
            var answerServiceProvider = botServiceProvider.GetAnswerServiceProvider(token);

            var cts = new CancellationTokenSource();

            var taskCount = botCoreOptionsProvider.Value.HandlersCount;
            var taskServices = Enumerable.Range(0, (int)taskCount)
                .Select(x => handleUpdatesLoopServiceTaskFactory.Create(answerServiceProvider, updatesQueue, updateHandler, cts.Token))
                .ToList();

            var updatesService = botServiceProvider.GetUpdateService(token);
            var receiptUpdatesTaskService = receiptUpdatesLoopServiceTaskFactory.Create(updatesService, updatesQueue, cts.Token);
            taskServices.Add(receiptUpdatesTaskService);

            return taskServices;
        }
    }
}
