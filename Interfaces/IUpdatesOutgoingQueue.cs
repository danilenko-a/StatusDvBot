using StatusDvBot.Models;
using StatusDvBot.Telegram;

namespace StatusDvBot.Interfaces
{
    internal interface IUpdatesOutgoingQueue
    {
        uint Count { get; }

        Result<Update> Dequeue();
    }
}