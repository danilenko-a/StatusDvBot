namespace StatusDvBot.Models
{
    internal readonly struct BotMethod
    {
        public string MethodName { get; }

        public bool ReturnsMessageId { get; }

        public BotMethod(string methodName, bool returnsMessageId)
        {
            MethodName = methodName;
            ReturnsMessageId = returnsMessageId;
        }
    }
}
