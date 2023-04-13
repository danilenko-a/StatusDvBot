using StatusDvBot.Telegram;

namespace StatusDvBot.Interfaces
{
    internal interface IUpdatesIncomingQueue
    {
        void Enqueue(Update update);
    }
}