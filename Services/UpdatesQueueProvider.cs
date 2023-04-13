using StatusDvBot.Interfaces;

namespace StatusDvBot.Services
{
    internal class UpdatesQueueProvider : IUpdatesQueueProvider
    {
        public UpdatesQueueProvider()
        {
            
        }

        IUpdatesQueue IUpdatesQueueProvider.Create()
        {
            return new UpdatesQueue();
        }
    }
}
