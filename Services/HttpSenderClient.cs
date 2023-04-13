using System.Text;

using StatusDvBot.Interfaces;
using StatusDvBot.Models;
namespace StatusDvBot.Services
{
    internal class HttpSenderClient : ISenderClient, IDisposable
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string token;

        public HttpSenderClient(string token)
        {
            this.token = token;
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }

        async Task<Result<string>> ISenderClient.SendFileAsync(Stream stream, string fileName, string methodName, long chatId)
        {
            var guid = Guid.NewGuid().ToString();
            using (var ms = new MemoryStream())
            {
                var buf = Encoding.UTF8.GetBytes($"--{guid}\r\n");
                ms.Write(buf, 0, buf.Length);

                buf = Encoding.UTF8.GetBytes("Content-Disposition: form-data; name=\"chat_id\"\r\n\r\n" + chatId + "\r\n");
                ms.Write(buf, 0, buf.Length);

                buf = Encoding.UTF8.GetBytes($"--{guid}\r\n");
                ms.Write(buf, 0, buf.Length);

                buf = Encoding.UTF8.GetBytes("Content-Disposition: form-data; name=\"document\"; filename=\"" + fileName + "\"\r\nContent-Type: application/octet-stream\r\nContent-Transfer-Encoding: binary\r\n\r\n");
                ms.Write(buf, 0, buf.Length);

                stream.CopyTo(ms);

                buf = Encoding.UTF8.GetBytes("\r\n");
                ms.Write(buf, 0, buf.Length);

                buf = Encoding.UTF8.GetBytes($"--{guid}--\r\n");
                ms.Write(buf, 0, buf.Length);

                ms.Position = 0;
                ms.Flush();

                var url = $"https://api.telegram.org/bot{token}/{methodName}";

                using (var content = new StreamContent(ms))
                {
                    content.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; boundary=" + guid);

                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();

                        return responseContent ?? Result.Empty<string>();
                    }
                }
            }
        }

        async Task<Result<string>> ISenderClient.SendStringAsync(string content, string methodName)
        {
            using (var requestContent = new StringContent(content, Encoding.UTF8, "application/json"))
            {
                var uri = $"https://api.telegram.org/bot{token}/{methodName}";
                var response = await httpClient.PostAsync(uri, requestContent, default);

                var responseContent = await response.Content.ReadAsStringAsync();

                return responseContent ?? Result.Empty<string>();
            }
        }
    }
}
