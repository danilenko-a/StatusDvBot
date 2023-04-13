using StatusDvBot.Interfaces;
using StatusDvBot.Models;

namespace StatusDvBot.Telegram
{
    public class DeleteMessage : IBotMessage
    {
        public long chat_id { get; set; }

        public long message_id { get; set; }

        object IBotMessage.Object => this;

        BotMethod IBotMessage.Method => new BotMethod("DeleteMessage", false);
    }
}
