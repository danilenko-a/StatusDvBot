namespace StatusDvBot.Telegram
{
    public class ReplyKeyboardMarkup : IReplyMarkup
    {
        public ReplyKeyboardMarkup()
        {
            resize_keyboard = true;
            keyboard = new List<List<KeyboardButton>>();
        }

        public List<List<KeyboardButton>> keyboard { get; set; }

        public bool resize_keyboard { get; set; }

        private void AddButton(KeyboardButton button)
        {
            if (keyboard.Count == 0)
                AddLine();

            keyboard.Last().Add(button);
        }

        private void AddLine(KeyboardButton button)
        {
            AddLine();
            AddButton(button);
        }

        #region IReplyMarkup Members
        public void AddButton(string text, string callbackData)
        {
            throw new InvalidDataException();
        }

        public void AddButton(string text, bool requestContact)
        {
            AddButton(new KeyboardButton() { text = text, request_contact = requestContact });
        }

        public void AddLine()
        {
            keyboard.Add(new List<KeyboardButton>());
        }

        public void AddLine(string text, string callbackData)
        {
            throw new InvalidDataException();
        }

        public void AddLine(string text, bool requestContact)
        {
            AddLine(new KeyboardButton() { text = text, request_contact = requestContact });
        }
        #endregion
    }
}
