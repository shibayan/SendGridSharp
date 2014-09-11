using System.Configuration;
using System.Net;
using System.Net.Mail;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SendGridSharp.Tests
{
    [TestClass]
    public class SendGridClientTest
    {
        [TestMethod]
        public void Send()
        {
            var client = new SendGridClient(new NetworkCredential(ConfigurationManager.AppSettings["ApiUser"], ConfigurationManager.AppSettings["ApiKey"]));

            var message = new SendGridMessage();

            message.To.Add(ConfigurationManager.AppSettings["MailTo"]);
            message.From = new MailAddress(ConfigurationManager.AppSettings["MailFrom"]);

            message.Header.AddSubstitution("-name-", "抱かれたい男 No.1");
            message.UseFooter("html", "text");

            message.Subject = "-name- さんへ";
            message.Body = "-name- さん";

            client.Send(message);
        }
    }
}
