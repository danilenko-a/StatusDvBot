namespace StatusDvBot.Telegram
{
    public class EditMessageCaption
    {
        public EditMessageCaption()
        {
            parse_mode = "Markdown";
        }

        public int chat_id { get; set; }

        public int message_id { get; set; }

        public string? parse_mode { get; set; }

        public object? reply_markup { get; set; }

        public string? caption { get; set; }
    }
}
