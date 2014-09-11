using System.Collections.Generic;

namespace SendGridSharp
{
    public static class SmtpHeaderExtensions
    {
        public static void UseBcc(this SmtpHeader header, string email)
        {
            header.AddFilter("bcc", new Dictionary<string, object>
            {
                { "enable", 1 },
                { "email", email }
            });
        }

        public static void UseBypassListManagement(this SmtpHeader header)
        {
            header.AddFilter("bypass_list_management", new Dictionary<string, object>
            {
                { "enable", 1 }
            });
        }

        public static void UseClickTrack(this SmtpHeader header)
        {
            header.AddFilter("clicktrack", new Dictionary<string, object>
            {
                { "enable", 1 }
            });
        }

        public static void UseDkim(this SmtpHeader header, string domain, bool useFrom)
        {
            header.AddFilter("dkim", new Dictionary<string, object>
            {
                { "domain", domain },
                { "use_from", useFrom }
            });
        }

        public static void UseDomainKeys(this SmtpHeader header, string domain, bool sender)
        {
            header.AddFilter("domainkeys", new Dictionary<string, object>
            {
                { "enable", 1 },
                { "domain", domain },
                { "sender", sender }
            });
        }

        public static void UseFooter(this SmtpHeader header, string html, string text)
        {
            header.AddFilter("footer", new Dictionary<string, object>
            {
                { "enable", 1 },
                { "text/html", html },
                { "text/plain", text }
            });
        }

        public static void UseForwardSpam(this SmtpHeader header, string email)
        {
            header.AddFilter("forwardspam", new Dictionary<string, object>
            {
                { "enable", 1 },
                { "email", email }
            });
        }

        public static void UseGoogleAnalytics(this SmtpHeader header, string source, string medium, string term, string content, string campaign)
        {
            header.AddFilter("ganalytics", new Dictionary<string, object>
            {
                { "enable", 1 },
                { "utm_source", source },
                { "utm_medium", medium },
                { "utm_term", term },
                { "utm_content", content },
                { "utm_campaign", campaign }
            });
        }

        public static void UseGravatar(this SmtpHeader header)
        {
            header.AddFilter("gravatar", new Dictionary<string, object>
            {
                { "enable", 1 }
            });
        }

        public static void UseOpenTrack(this SmtpHeader header)
        {
            header.AddFilter("opentrack", new Dictionary<string, object>
            {
                { "enable", 1 }
            });
        }

        public static void UseSpamCheck(this SmtpHeader header, double maxscore, string url)
        {
            header.AddFilter("spamcheck", new Dictionary<string, object>
            {
                { "enable", 1 },
                { "maxscore", maxscore },
                { "url", url }
            });
        }

        public static void UseSubscriptionTrack(this SmtpHeader header, string html, string text, string replace)
        {
            header.AddFilter("subscriptiontrack", new Dictionary<string, object>
            {
                { "enable", 1 },
                { "text/html", html },
                { "text/plain", text },
                { "replace", replace }
            });
        }

        public static void UseTemplateEngine(this SmtpHeader header, string templateId)
        {
            header.AddFilter("templates", new Dictionary<string, object>
            {
                { "enable", 1 },
                { "template_id", templateId },
            });
        }

        public static void UseTemplate(this SmtpHeader header, string html)
        {
            header.AddFilter("template", new Dictionary<string, object>
            {
                { "enable", 1 },
                { "text/html", html },
            });
        }
    }
}
