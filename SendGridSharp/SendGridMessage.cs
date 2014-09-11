using System.Net.Mail;

namespace SendGridSharp
{
    public class SendGridMessage : MailMessage
    {
        private readonly SmtpHeader _header = new SmtpHeader();

        public SmtpHeader Header
        {
            get { return _header; }
        }
    }
}
