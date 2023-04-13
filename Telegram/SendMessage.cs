namespace StatusDvBot.Telegram
{
    internal class SendMessage<T>: Send<T> where T : class, IReplyMarkup, new()
    {
        public SendMessage()
        {
            parse_mode = "Markdown";
        }

        public static SendMessage<T> GetSendMessage(string text, Update update)
        {
            return new SendMessage<T>
            {
                chat_id = update.callback_query?.message?.chat?.id ?? update.message?.chat?.id ?? 0,
                text = text,
                reply_markup = new T()
            };
        }

        public string? text { get; set; }

        public override string MethodName => "SendMessage";
    }
}
