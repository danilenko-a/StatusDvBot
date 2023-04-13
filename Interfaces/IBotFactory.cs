namespace StatusDvBot.Interfaces
{
    /// <summary>
    /// Фабрика телеграм-ботов
    /// </summary>
    internal interface IBotFactory
    {
        /// <summary>
        /// Создать телеграм-бот
        /// </summary>
        /// <param name="token">Токен</param>
        /// <param name="updateHandler">Обработчик сообщений от пользователей</param>
        ITgBot Create(string token, IUpdateHandler updateHandler);
    }
}
