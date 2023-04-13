namespace StatusDvBot.Interfaces
{
    /// <summary>
    /// Провайдер сервисов ответов
    /// </summary>
    internal interface IAnswerServiceProvider
    {
        /// <summary>
        /// Получить сервис ответов пользователю
        /// </summary>
        IAnswerService Get();
    }
}
