namespace StatusDvBot.Telegram
{
    public class EditMessageMedia : EditMessage
    {
        public EditMessageMedia()
        {
            reply_markup = new InlineKeyboardMarkup();
        }

        public static EditMessageMedia GetFromUpdate(string caption, Update update, string photo)
        {
            var item = new EditMessageMedia
            {
                chat_id = update.callback_query?.message?.chat?.id ?? -1,
                message_id = update.callback_query?.message?.message_id ?? -1,
                media = new InputMedia
                {
                    caption = caption,
                    media = photo,
                },
            };
            return item;
        }

        public InputMedia? media { get; set; }

        public override string MethodName => "editMessageMedia";
    }
}
