namespace StatusDvBot.Telegram
{
    public class Update
    {
        public long update_id { get; set; }

        public Message? message { get; set; }

        public CallbackQuery? callback_query { get; set; }

        public override string ToString()
        {
            var chat = message?.chat ?? callback_query?.message?.chat;
            var @from = message?.from ?? callback_query?.from;
            var @data = message?.contact?.phone_number ?? message?.text ?? callback_query?.data;

            return $"chatId: {chat?.id} name: {from?.first_name} data: {data}";
        }
    }
}
