using StatusDvBot.Interfaces;

namespace StatusDvBot.Services
{
    internal class TgBot : ITgBot
    {
        private readonly ITaskService taskService;

        private uint isStarted = 0;

        public TgBot(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        void ITgBot.Start()
        {
            if (Interlocked.CompareExchange(ref isStarted, 1, 0) != 0)
            {
                throw new InvalidOperationException("Бот уже запущен");
            }

            taskService.Start();
        }

        async Task ITgBot.StopAsync()
        {
            if (Interlocked.CompareExchange(ref isStarted, 0, 1) != 1)
            {
                throw new InvalidOperationException("Бот не запущен");
            }

            await taskService.StopAsync();
        }
    }
}
