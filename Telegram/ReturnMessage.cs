namespace StatusDvBot.Telegram
{
    public class ReturnMessage
    {
        public bool ok { get; set; }

        public Message? result { get; set; }

        public int error_code { get; set; }

        public string? description { get; set; }
    }
}
