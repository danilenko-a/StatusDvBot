using StatusDvBot.Interfaces;

namespace StatusDvBot.Telegram
{
    internal class FileStreamDocument : IBotFile
    {
        public Stream Object { get; }

        public string MethodName => "SendDocument";

        public string FileName { get; }

        public long ChatId { get; }

        public FileStreamDocument(FileStream fileStream, string filename, long chatId)
        {
            Object = fileStream;
            FileName = filename;
            ChatId = chatId;
        }
    }
}
