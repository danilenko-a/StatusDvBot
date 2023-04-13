namespace StatusDvBot.Telegram
{
    public class InputMedia
    {
        public InputMedia()
        {
            type = "photo";
            parse_mode = "Markdown";
        }

        public string? type { get; set; }

        public string? media { get; set; }

        public string? caption { get; set; }

        public string? parse_mode { get; set; }
    }
}