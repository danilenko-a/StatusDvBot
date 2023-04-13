using StatusDvBot.Models;

namespace StatusDvBot.Interfaces
{
    /// <summary>
    /// Сообщение пользователю
    /// </summary>
    internal interface IBotMessage
    {
        /// <summary>
        /// Объект сообщения
        /// </summary>
        object Object { get; }

        /// <summary>
        /// Метод отправки
        /// </summary>
        BotMethod Method { get; }
    }
}
