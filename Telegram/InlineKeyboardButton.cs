namespace StatusDvBot.Telegram
{
    public class InlineKeyboardButton : Button
    {
        public InlineKeyboardButton() { }

        public InlineKeyboardButton(string text, string callback_data)
        {
            this.text = text;
            this.callback_data = callback_data;
        }

        public string? callback_data { get; set; }

        public override string ToString()
        {
            return $"{text}:{callback_data}";
        }
    }
}