using System.Text.Json;

using StatusDvBot.Interfaces;

namespace StatusDvBot.Services
{
    internal class JsonSerializeService : ISerializeService
    {
        public JsonSerializeService()
        {
            
        }

        string ISerializeService.Serialize(object value)
        {
            var data = JsonSerializer.Serialize(value, value.GetType());
            return data;
        }
    }
}
