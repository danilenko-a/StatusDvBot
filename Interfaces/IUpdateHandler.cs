using StatusDvBot.Telegram;

namespace StatusDvBot.Interfaces
{
    internal interface IUpdateHandler
    {
        Task Handle(Update update, IAnswerService botSender);
    }
}