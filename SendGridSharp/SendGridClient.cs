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

            var responseContent = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<GenericResult>(responseContent);

            if (!result.IsSuccess)
            {
                throw new SendGridException(result.Errors[0]);
            }
        }

        public async Task SendAsync(SendGridMessage message)
        {
            var content = GetContent(message);

            var client = new HttpClient();

            var response = await client.PostAsync(Endpoint, content);

            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<GenericResult>(responseContent);

            if (!result.IsSuccess)
            {
                throw new SendGridException(result.Message);
            }
        }

        private MultipartFormDataContent GetContent(SendGridMessage message)
        {
            var content = new MultipartFormDataContent
            {
                { new StringContent(_credentials.UserName), "api_user" },
                { new StringContent(_credentials.Password), "api_key" },
                { new StringContent(JsonConvert.SerializeObject(message.Headers)), "headers" },
                { new StringContent(message.From), "from" },
                { new StringContent(message.Subject), "subject" },
                { new StringContent(message.Header.ToString()), "x-smtpapi" }
            };

            if (message.ReplyTo != null)
            {
                content.Add(new StringContent(message.ReplyTo), "replyto");
            }

            if (message.Text != null)
            {
                content.Add(new StringContent(message.Text), "text");
            }

            if (message.Html != null)
            {
                content.Add(new StringContent(message.Html), "html");
            }

            if (message.Date.HasValue)
            {
                content.Add(new StringContent(message.Date.Value.ToString("r")), "date");
            }

            foreach (var to in message.To)
            {
                content.Add(new StringContent(to), "to[]");
            }

            foreach (var bcc in message.Bcc)
            {
                content.Add(new StringContent(bcc), "bcc[]");
            }

            foreach (var cc in message.Cc)
            {
                content.Add(new StringContent(cc), "cc[]");
            }

            foreach (var item in message.Files)
            {
                content.Add(new StreamContent(item.Value), "files[" + item.Key + "]");
            }

            foreach (var item in message.Content)
            {
                content.Add(new StringContent(item.Value), "content[" + item.Key + "]");
            }

            return content;
        }
    }
}
