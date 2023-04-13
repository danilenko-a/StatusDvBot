namespace StatusDvBot.Interfaces
{
    /// <summary>
    /// Файл, отправляемый пользователю
    /// </summary>
    internal interface IBotFile
    {
        /// <summary>
        /// Поток файла
        /// </summary>
        Stream Object { get; }

        /// <summary>
        /// Имя метода отправки файла
        /// </summary>
        string MethodName { get; }

        /// <summary>
        /// Имя файла
        /// </summary>
        string FileName { get; }

        /// <summary>
        /// Идентификатор чата с пользователем
        /// </summary>
        long ChatId { get; }
    }
}
