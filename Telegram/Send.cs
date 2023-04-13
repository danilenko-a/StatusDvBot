using StatusDvBot.Interfaces;
using StatusDvBot.Models;

namespace StatusDvBot.Telegram
{
    internal abstract class Send<T> : IBotMessage 
        where T : IReplyMarkup, new()
    {
        public long chat_id { get; set; }

        public string? parse_mode { get; set; }

        public T? reply_markup { get; set; }

        public abstract string MethodName { get; }

        object IBotMessage.Object => this;

        BotMethod IBotMessage.Method => new BotMethod(MethodName, true);
    }
}
