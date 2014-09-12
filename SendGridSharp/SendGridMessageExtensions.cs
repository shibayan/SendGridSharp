using System;
using System.IO;

namespace SendGridSharp
{
    public static class SendGridMessageExtensions
    {
        public static void UseBcc(this SendGridMessage message, string email)
        {
            message.Header.UseBcc(email);
        }

        public static void UseBypassListManagement(this SendGridMessage message)
        {
            message.Header.UseBypassListManagement();
        }

        public static void UseClickTrack(this SendGridMessage message)
        {
            message.Header.UseClickTrack();
        }

        public static void UseDkim(this SendGridMessage message, string domain, bool useFrom)
        {
            message.Header.UseDkim(domain, useFrom);
        }

        public static void UseDomainKeys(this SendGridMessage message, string domain, bool sender)
        {
            message.Header.UseDomainKeys(domain, sender);
        }

        public static void UseFooter(this SendGridMessage message, string html, string text)
        {
            message.Header.UseFooter(html, text);
        }

        public static void UseForwardSpam(this SendGridMessage message, string email)
        {
            message.Header.UseForwardSpam(email);
        }

        public static void UseGoogleAnalytics(this SendGridMessage message, string source, string medium, string term, string content, string campaign)
        {
            message.Header.UseGoogleAnalytics(source, medium, term, content, campaign);
        }

        public static void UseGravatar(this SendGridMessage message)
        {
            message.Header.UseGravatar();
        }

        public static void UseOpenTrack(this SendGridMessage message)
        {
            message.Header.UseOpenTrack();
        }

        public static void UseSpamCheck(this SendGridMessage message, double maxscore, string url)
        {
            message.Header.UseSpamCheck(maxscore, url);
        }

        public static void UseSubscriptionTrack(this SendGridMessage message, string html, string text, string replace)
        {
            message.Header.UseSubscriptionTrack(html, text, replace);
        }

        public static void UseTemplateEngine(this SendGridMessage message, string templateId)
        {
            message.Header.UseTemplateEngine(templateId);
        }

        public static void UseTemplate(this SendGridMessage message, string html)
        {
            message.Header.UseTemplate(html);
        }

        public static void AddAttachment(this SendGridMessage message, string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            AddAttachment(message, path, Path.GetFileName(path));
        }

        public static void AddAttachment(this SendGridMessage message, string path, string fileName)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }

            message.Files.Add(fileName, File.OpenRead(path));
        }
    }
}
