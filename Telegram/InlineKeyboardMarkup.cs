namespace StatusDvBot.Telegram
{
    public class InlineKeyboardMarkup : IReplyMarkup
    {
        public InlineKeyboardMarkup()
        {
            inline_keyboard = new List<List<InlineKeyboardButton>>();
        }

        public List<List<InlineKeyboardButton>> inline_keyboard { get; set; }

        private void AddButton(InlineKeyboardButton button)
        {
            if (inline_keyboard.Count == 0)
                AddLine();

            inline_keyboard.Last().Add(button);
        }

        private void AddLine(InlineKeyboardButton button)
        {
            AddLine();
            AddButton(button);
        }

        #region IReplyMarkup Members
        public void AddButton(string text, string callbackData)
        {
            AddButton(new InlineKeyboardButton(text, callbackData));
        }

        public void AddButton(string text, bool requestContact)
        {
            throw new InvalidDataException();
        }

        public void AddLine()
        {
            inline_keyboard.Add(new List<InlineKeyboardButton>());
        }

        public void AddLine(string text, string callbackData)
        {
            AddLine(new InlineKeyboardButton(text, callbackData));
        }

        public void AddLine(string text, bool requestContact)
        {
            throw new InvalidDataException();
        }
        #endregion
    }
}