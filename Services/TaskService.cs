using StatusDvBot.Interfaces;

namespace StatusDvBot.Services
{
    internal class TaskService : ITaskService
    {
        private readonly Task task;

        public TaskService(Task task)
        {
            this.task = task;
        }

        void ITaskService.Start()
        {
            task.Start();
        }

        Task ITaskService.StopAsync()
        {
            return task;
        }
    }
}
