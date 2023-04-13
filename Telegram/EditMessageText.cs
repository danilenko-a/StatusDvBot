namespace StatusDvBot.Telegram
{
    public class EditMessageText : EditMessage
    {
        public EditMessageText()
        {
            parse_mode = "Markdown";
            reply_markup = new InlineKeyboardMarkup();
        }

        public static EditMessageText GetEditMessageText(string text, Update update)
        {
            return new EditMessageText
            {
                chat_id = update.callback_query?.message?.chat?.id ?? 0,
                text = text,
                message_id = update.callback_query?.message?.message_id ?? 0,
            };
        }
        public static EditMessageText GetEditMessageText(Update update)
        {
            return GetEditMessageText("", update);
        }

        public string? text { get; set; }

        public string? parse_mode { get; set; }

        public override string MethodName => "EditMessageText";
    }
}
