namespace StatusDvBot.Models
{
    internal class BotCoreOptions
    {
        public uint HandlersCount { get; }

        public BotCoreOptions(uint handlersCount)
        {
            if (handlersCount == 0)
            {
                throw new ArgumentException("Количество обработчиков должно быть больше 0", nameof(handlersCount));
            }

            HandlersCount = handlersCount;
        }
    }
}
