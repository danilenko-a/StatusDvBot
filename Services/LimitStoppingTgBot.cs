using StatusDvBot.Interfaces;

namespace StatusDvBot.Services
{
    internal class LimitStoppingTgBot : ITgBot
    {
        public const uint LIMIT_WAIT_SECONDS = 15;

        private readonly ITgBot decoratee;

        public LimitStoppingTgBot(ITgBot decoratee)
        {
            this.decoratee = decoratee;
        }

        void ITgBot.Start()
        {
            decoratee.Start();
        }

        async Task ITgBot.StopAsync()
        {
            var interruptingTask = Task.Delay(TimeSpan.FromSeconds(LIMIT_WAIT_SECONDS));
            await await Task.WhenAny(interruptingTask, decoratee.StopAsync());
        }
    }
}
