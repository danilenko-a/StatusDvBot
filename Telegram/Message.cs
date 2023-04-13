namespace StatusDvBot.Telegram
{
    public class Message
    {
        public Message()
        {
            reply_markup = new InlineKeyboardMarkup();
        }

        public long message_id { get; set; }

        public User? from { get; set; }

        public Chat? chat { get; set; }

        public long date { get; set; }

        public string? text { get; set; }

        public Message? reply_to_message { get; set; }

        public List<MessageEntity>? entities { get; set; }

        public Contact? contact { get; set; }

        public InlineKeyboardMarkup? reply_markup { get; set; }
    }
}
