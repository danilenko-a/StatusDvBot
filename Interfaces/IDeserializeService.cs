using StatusDvBot.Models;

namespace StatusDvBot.Interfaces
{
    /// <summary>
    /// Сервис десериализации
    /// </summary>
    internal interface IDeserializeService
    {
        /// <summary>
        /// Десериализовать строку в объект
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="data">Данные</param>
        Result<T> Deserialize<T>(string data);
    }
}
