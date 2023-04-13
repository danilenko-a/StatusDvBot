namespace StatusDvBot.Interfaces
{
    /// <summary>
    /// Провайдер сервисов, необходимых для работы телеграм-бота
    /// </summary>
    internal interface IBotServiceProvider
    {
        /// <summary>
        /// Получить сервис, который получает обновления от телеграма (сообщения пользователей)
        /// </summary>
        IUpdatesService GetUpdateService(string token);

        /// <summary>
        /// Получить сервис, отправляющий ответы пользователю
        /// </summary>
        IAnswerServiceProvider GetAnswerServiceProvider(string token);
    }
}
