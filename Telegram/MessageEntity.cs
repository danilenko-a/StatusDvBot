namespace StatusDvBot.Telegram
{
    public class MessageEntity
    {
        public string? @type { get; set; }

        public long offset { get; set; }

        public long length { get; set; }
    }
}
