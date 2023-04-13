using System.Text.Json;

using StatusDvBot.Interfaces;
using StatusDvBot.Models;

namespace StatusDvBot.Services
{
    internal class JsonDeserializeService : IDeserializeService
    {
        public JsonDeserializeService()
        {
            
        }
        Result<T> IDeserializeService.Deserialize<T>(string data)
        {
            return JsonSerializer.Deserialize<T>(data) ?? Result.Empty<T>();
        }
    }
}
