using System.Collections.Concurrent;

using StatusDvBot.Interfaces;
using StatusDvBot.Models;
using StatusDvBot.Telegram;

namespace StatusDvBot.Services
{
    internal class UpdatesQueue : IUpdatesQueue
    {
        private readonly ConcurrentQueue<Update> queue = new ConcurrentQueue<Update>(); 

        public UpdatesQueue()
        {
            
        }

        uint IUpdatesOutgoingQueue.Count => (uint) queue.Count;

        void IUpdatesIncomingQueue.Enqueue(Update update)
        {
            queue.Enqueue(update);
        }

        Result<Update> IUpdatesOutgoingQueue.Dequeue()
        {
            Update? result;
            if (queue.TryDequeue(out result))
            {
                return result;
            }

            return Result.Empty<Update>();
        }
    }
}
