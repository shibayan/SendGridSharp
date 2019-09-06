using System;
using System.Collections.Generic;
using System.IO;

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

        public List<string> To { get; } = new List<string>();

        public List<string> Cc { get; } = new List<string>();

        public List<string> Bcc { get; } = new List<string>();

        public SmtpHeader Header { get; } = new SmtpHeader();

        public Dictionary<string, string> Headers { get; } = new Dictionary<string, string>();

        public Dictionary<string, Stream> Files { get; } = new Dictionary<string, Stream>();

        public Dictionary<string, string> Content { get; } = new Dictionary<string, string>();

        public string From { get; set; }

        public string FromName { get; set; }

        public string ReplyTo { get; set; }

        public string Subject { get; set; }

        public string Text { get; set; }

        public string Html { get; set; }

        public DateTimeOffset? Date { get; set; }
    }
}
