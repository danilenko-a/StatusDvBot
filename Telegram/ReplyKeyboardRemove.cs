namespace StatusDvBot.Telegram
{
    public class ReplyKeyboardRemove : IReplyMarkup
    {
        public ReplyKeyboardRemove()
        {
            remove_keyboard = true;
        }

        public bool remove_keyboard { get; set; }

        #region IReplyMarkup Members
        public void AddButton(string text, string callbackData)
        {
            throw new InvalidDataException();
        }

        public void AddButton(string text, bool requestContact)
        {
            throw new InvalidDataException();
        }

        public void AddLine()
        {
            throw new InvalidDataException();
        }

        public void AddLine(string text, string callbackData)
        {
            throw new InvalidDataException();
        }

        public void AddLine(string text, bool requestContact)
        {
            throw new InvalidDataException();
        }
        #endregion
    }
}
