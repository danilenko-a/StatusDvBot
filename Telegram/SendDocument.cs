namespace StatusDvBot.Telegram
{
    public class SendDocument
    {
        public long chat_id { get; set; }

        public byte[]? document { get; set; }
    }
}
