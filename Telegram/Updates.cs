namespace StatusDvBot.Telegram
{
    public class Updates
    {
        public bool ok { get; set; }

        public List<Update>? result { get; set; }

        public int error_code { get; set; }

        public string? description { get; set; }
    }
}
