using StatusDvBot.Interfaces;
using StatusDvBot.Models;
using StatusDvBot.Telegram;

namespace StatusDvBot.Services
{
    internal class AnswerService : IAnswerService
    {
        private readonly ISerializeService serializeService;
        private readonly IDeserializeService deserializeService;
        private readonly ISenderClient senderClient;

        public AnswerService(ISerializeService serializeService, ISenderClient senderClient, IDeserializeService deserializeService)
        {
            this.serializeService = serializeService;
            this.senderClient = senderClient;
            this.deserializeService = deserializeService;
        }

        async Task IAnswerService.SendDocumentAsync(IBotFile botFile)
        {
            var content = await senderClient.SendFileAsync(botFile.Object, botFile.FileName, botFile.MethodName, botFile.ChatId);
        }

        async Task<Result<long>> IAnswerService.SendMessage(IBotMessage botMessage)
        {
            var data = serializeService.Serialize(botMessage.Object);
            var content = await senderClient.SendStringAsync(data, botMessage.Method.MethodName);
            if (botMessage.Method.ReturnsMessageId && content.HasValue && content.Value != "")
            {
                var returnMessageResult = deserializeService.Deserialize<ReturnMessage>(content.Value);
                if (returnMessageResult.HasValue)
                {
                    var returnMessage = returnMessageResult.Value;

                    if (!returnMessage.ok)
                    {
                        throw new ApplicationException($"{returnMessage.error_code} - {returnMessage.description}");
                    }

                    if (returnMessage.result?.message_id > 0)
                    {
                        return returnMessage.result.message_id;
                    }
                }
            }

            return Result.Empty<long>();
        }
    }
}
