namespace StatusDvBot.Telegram
{
    public class CallbackQuery
    {
        public string? id { get; set; }

        public User? from { get; set; } 

        public Message? message { get; set; }

        public string? chat_instance { get; set; }

        //Имя команды
        public string? data { get; set; }

        public override string ToString()
        {
            return $"id:{id}, data:{data}";
        }
    }
}
