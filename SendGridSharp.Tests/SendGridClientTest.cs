using System;
using System.Threading;
using System.Threading.Tasks;

using Xunit;

namespace SendGridSharp.Tests
{
    public class SendGridClientTest
    {
        [Fact]
        public void Send()
        {
            var client = new SendGridClient(Environment.GetEnvironmentVariable("ApiKey"));

            var message = new SendGridMessage();

            message.To.Add(Environment.GetEnvironmentVariable("MailTo"));
            message.From = Environment.GetEnvironmentVariable("MailFrom");

            message.Header.AddSubstitution("-name-", "抱かれたい男 No.1");
            message.UseFooter("html", "text");

            message.Subject = "-name- さんへ";
            message.Text = "-name- さん";
            message.Html = "<p>-name- さん</p>";

            client.Send(message);
        }

        [Fact]
        public async Task SendAsync()
        {
            var client = new SendGridClient(Environment.GetEnvironmentVariable("ApiKey"));

            var message = new SendGridMessage();

            message.To.Add(Environment.GetEnvironmentVariable("MailTo"));
            message.From = Environment.GetEnvironmentVariable("MailFrom");

            message.Header.AddSubstitution("-name-", "抱かれたい男 No.1");
            message.UseFooter("html", "text");

            message.Subject = "-name- さんへ";
            message.Text = "-name- さん";
            message.Html = "<p>-name- さん</p>";

            await client.SendAsync(message);
        }

        [Fact]
        public void Schedule()
        {
            var client = new SendGridClient(Environment.GetEnvironmentVariable("ApiKey"));

            var message = new SendGridMessage();

            message.To.Add(Environment.GetEnvironmentVariable("MailTo"));
            message.From = Environment.GetEnvironmentVariable("MailFrom");

            message.Header.AddSubstitution("-name-", "抱かれたい男 No.1");
            message.Header.AddSendAt(DateTimeOffset.Now.AddSeconds(30));

            message.Subject = "-name- さんへ";
            message.Text = "-name- さん";
            message.Html = "<p>-name- さん</p>";

            client.Send(message);
        }

        [Fact]
        public void ScheduleMulti()
        {
            var client = new SendGridClient(Environment.GetEnvironmentVariable("ApiKey"));

            var sendAt = DateTimeOffset.Now.AddMinutes(15);

            for (int i = 0; i < 5; i++)
            {
                var message = new SendGridMessage();

                message.To.Add(Environment.GetEnvironmentVariable("MailTo"));
                message.From = Environment.GetEnvironmentVariable("MailFrom");

                message.Header.AddSubstitution("-name-", "抱かれたい男 No.1");
                message.Header.AddSendAt(sendAt);

                message.Subject = "-name- さんへ" + i;
                message.Text = "-name- さん";
                message.Html = "<p>-name- さん</p>";

                client.Send(message);

                Thread.Sleep(200);
            }
        }

        [Fact]
        public void Attachment()
        {
            var client = new SendGridClient(Environment.GetEnvironmentVariable("ApiKey"));

            var message = new SendGridMessage();

            message.To.Add(Environment.GetEnvironmentVariable("MailTo"));
            message.From = Environment.GetEnvironmentVariable("MailFrom");

            message.Subject = "file attachment";
            message.Text = "file attachment test";

            message.AddAttachment(Environment.GetEnvironmentVariable("AttachmentImage"));

            client.Send(message);
        }

        [Fact]
        public void EmbedImage()
        {
            var client = new SendGridClient(Environment.GetEnvironmentVariable("ApiKey"));

            var message = new SendGridMessage();

            message.To.Add(Environment.GetEnvironmentVariable("MailTo"));
            message.From = Environment.GetEnvironmentVariable("MailFrom");

            message.Subject = "file attachment";
            message.Html = "file attachment test<br /><img src=\"cid:hogehoge\" /><br />inline image";

            message.AddAttachment(Environment.GetEnvironmentVariable("AttachmentImage"), "maki.jpg");
            message.Content.Add("maki.jpg", "hogehoge");

            client.Send(message);
        }

        [Fact]
        public void TemplateEngine()
        {
            var client = new SendGridClient(Environment.GetEnvironmentVariable("ApiKey"));

            var message = new SendGridMessage();

            message.To.Add(Environment.GetEnvironmentVariable("MailTo"));
            message.From = Environment.GetEnvironmentVariable("MailFrom");

            message.Subject = " ";
            message.Text = " ";

            message.UseTemplateEngine("91ba5fd7-984c-4810-95fd-030be7242106");

            message.Header.AddSubstitution("-name-", "抱かれたい男 No.1");
            message.Header.AddSubstitution("-url-", "http://buchizo.wordpress.com/");

            client.Send(message);
        }

        [Fact]
        public void OpenTrack()
        {
            var client = new SendGridClient(Environment.GetEnvironmentVariable("ApiKey"));

            var message = new SendGridMessage();

            message.To.Add(Environment.GetEnvironmentVariable("MailTo"));
            message.From = Environment.GetEnvironmentVariable("MailFrom");

            message.Header.AddSubstitution("-name-", "抱かれたい男 No.1");
            message.UseFooter("html", "text");

            message.Subject = "-name- さんへ";
            message.Text = "-name- さん";
            message.Html = "<p>-name- さん</p>";

            message.UseOpenTrack();

            client.Send(message);
        }
    }
}
