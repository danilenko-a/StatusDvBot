using StatusDvBot.Interfaces;

namespace StatusDvBot.Services
{
    internal class CompositeTaskService : ITaskService
    {
        private readonly IEnumerable<ITaskService> taskServices;

        public CompositeTaskService(IEnumerable<ITaskService> taskServices)
        {
            this.taskServices = taskServices;
        }

        void ITaskService.Start()
        {
            foreach (var updatesLoopService in taskServices)
            {
                updatesLoopService.Start();
            }
        }

        async Task ITaskService.StopAsync()
        {
            foreach (var updatesLoopService in taskServices)
            {
                await updatesLoopService.StopAsync();
            }
        }
    }
}
