using StatusDvBot.Interfaces;
using StatusDvBot.Models;

namespace StatusDvBot.Telegram
{
    public abstract class EditMessage : IBotMessage
    {
        public long chat_id { get; set; }

        public long message_id { get; set; }

        public InlineKeyboardMarkup? reply_markup { get; set; }

        public abstract string MethodName { get; }

        object IBotMessage.Object => this;

        BotMethod IBotMessage.Method => new BotMethod(MethodName, true);
    }
}
