namespace StatusDvBot.Telegram
{
    public class Contact
    {
        public string? phone_number { get; set; }

        public string? first_name { get; set; }

        /// <summary>
        /// Совпадает с ИД чата
        /// </summary>
        public long user_id { get; set; }

        public string? vcard { get; set; }
    }
}
