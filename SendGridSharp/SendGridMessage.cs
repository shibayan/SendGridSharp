using System.Collections.Generic;

namespace SendGridSharp
{
    public class SendGridMessage
    {
        public SendGridMessage()
        {
        }

        public SendGridMessage(string from, params string[] to)
        {
            From = from;
            To.AddRange(to);
        }

        private readonly List<string> _to = new List<string>();
        private readonly List<string> _replyTo = new List<string>();
        private readonly SmtpHeader _header = new SmtpHeader();
        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>();

        public List<string> To
        {
            get { return _to; }
        }

        public List<string> ReplyTo
        {
            get { return _replyTo; }
        }

        public SmtpHeader Header
        {
            get { return _header; }
        }

        public Dictionary<string, string> Headers
        {
            get { return _headers; }
        }

        public string From { get; set; }

        public string Subject { get; set; }

        public string Text { get; set; }

        public string Html { get; set; }
    }
}
