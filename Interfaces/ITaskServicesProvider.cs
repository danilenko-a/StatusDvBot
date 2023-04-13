using StatusDvBot.Services;

namespace StatusDvBot.Interfaces
{
    internal interface ITaskServicesProvider
    {
        IEnumerable<ITaskService> Create(string token, IUpdateHandler updateHandler);
    }
}
