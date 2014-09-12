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

        private readonly List<string> _to = new List<string>();
        private readonly List<string> _cc = new List<string>();
        private readonly List<string> _bcc = new List<string>();
        private readonly SmtpHeader _header = new SmtpHeader();
        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>();
        private readonly Dictionary<string, Stream> _files = new Dictionary<string, Stream>();
        private readonly Dictionary<string, string> _content = new Dictionary<string, string>();

        public List<string> To
        {
            get { return _to; }
        }

        public List<string> Cc
        {
            get { return _cc; }
        }

        public List<string> Bcc
        {
            get { return _bcc; }
        }

        public SmtpHeader Header
        {
            get { return _header; }
        }

        public Dictionary<string, string> Headers
        {
            get { return _headers; }
        }

        public Dictionary<string, Stream> Files
        {
            get { return _files; }
        }

        public Dictionary<string, string> Content
        {
            get { return _content; }
        }

        public string From { get; set; }

        public string ReplyTo { get; set; }

        public string Subject { get; set; }

        public string Text { get; set; }

        public string Html { get; set; }

        public DateTimeOffset? Date { get; set; }
    }
}
