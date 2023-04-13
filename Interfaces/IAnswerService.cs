using StatusDvBot.Models;

namespace StatusDvBot.Interfaces
{
    /// <summary>
    /// Сервис отправки ответов пользователю
    /// </summary>
    internal interface IAnswerService
    {
        /// <summary>
        /// Отправить сообщение пользователю
        /// </summary>
        Task<Result<long>> SendMessage(IBotMessage botMessage);

        /// <summary>
        /// Отправить файл пользователю
        /// </summary>
        Task SendDocumentAsync(IBotFile botFile);
    }
}
