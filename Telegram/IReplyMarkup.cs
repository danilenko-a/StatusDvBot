namespace StatusDvBot.Telegram
{
    public interface IReplyMarkup
    {
        void AddLine();

        void AddLine(string text, string callbackData);

        void AddButton(string text, string callbackData);

        void AddLine(string text, bool requestContact);

        void AddButton(string text, bool requestContact);
    }
}