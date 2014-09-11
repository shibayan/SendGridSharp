using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace SendGridSharp
{
    public class SendGridClient
    {
        public SendGridClient(NetworkCredential credentials)
        {
            _credentials = credentials;
        }

        private const string Endpoint = "https://api.sendgrid.com/api/mail.send.json";

        private readonly NetworkCredential _credentials;

        public void Send(SendGridMessage message)
        {
            var content = GetContent(message);

            var client = new HttpClient();

            var response = client.PostAsync(Endpoint, content).Result;

            response.EnsureSuccessStatusCode();
        }

        public async Task SendAsync(SendGridMessage message)
        {
            var content = GetContent(message);

            var client = new HttpClient();

            var response = await client.PostAsync(Endpoint, content);

            response.EnsureSuccessStatusCode();
        }

        private MultipartFormDataContent GetContent(SendGridMessage message)
        {
            var content = new MultipartFormDataContent
            {
                { new StringContent(_credentials.UserName), "api_user" },
                { new StringContent(_credentials.Password), "api_key" },
                { new StringContent(JsonConvert.SerializeObject(message.Headers)), "headers" },
                { new StringContent(message.ReplyToList.Count != 0 ? message.ReplyToList[0].Address : ""), "replyto" },
                { new StringContent(message.From.Address), "from" },
                { new StringContent(message.From.DisplayName), "fromname" },
                { new StringContent(message.Subject), "subject" },
                { new StringContent(message.Body), "text" },
                { new StringContent(message.Header.ToString()), "x-smtpapi" }
            };

            foreach (var to in message.To)
            {
                content.Add(new StringContent(to.Address), "to[]");
                content.Add(new StringContent(to.DisplayName), "toname[]");
            }

            return content;
        }
    }
}
