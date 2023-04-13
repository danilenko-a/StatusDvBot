namespace StatusDvBot.Models
{
    internal class TelegramBotOptions
    {
        public string Name { get; }

        public string Token { get; }

        public TelegramBotOptions(string? name, string? token)
        {
            Name = name ?? string.Empty;
            Token = token ?? string.Empty;
        }
    }
}
