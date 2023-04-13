namespace StatusDvBot.Telegram
{
    internal class SendPhoto<T> : Send<T> where T : IReplyMarkup, new()
    {
        public SendPhoto()
        {
            parse_mode = "Markdown";
        }

        internal static SendPhoto<T> GetSendMain(string caption, Update update, string photo)
        {
            return new SendPhoto<T>
            {
                chat_id = update.callback_query?.message?.chat?.id ?? update.message?.chat?.id ?? 0,
                caption = caption,
                reply_markup = new T(),
                photo = photo,
            };
        }

        public string? photo { get; set; }

        public string? caption { get; set; }

        public override string MethodName => "SendPhoto";
    }
}
