using System.Collections.Generic;

using Xunit;

namespace SendGridSharp.Tests
{
    public class SmtpHeaderTest
    {
        [Fact]
        public void TestAddTo()
        {
            var header = new SmtpHeader();

            // Arrange
            header.AddTo(new List<string> { "joe@example.com", "jane@example.com" });

            // Actual
            var result = header.ToString();

            Assert.Equal("{\"to\":[\"joe@example.com\",\"jane@example.com\"]}", result);
        }

        [Fact]
        public void TestAddSubstitution()
        {
            var header = new SmtpHeader();

            // Arrange
            header.AddSubstitution("foo", new List<string> { "bar", "raz" });

            // Actual
            var result = header.ToString();

            Assert.Equal("{\"sub\":{\"foo\":[\"bar\",\"raz\"]}}", result);
        }

        [Fact]
        public void TestAddSection()
        {
            var header = new SmtpHeader();

            // Arrange
            header.AddSection("foo", "bar");

            // Actual
            var result = header.ToString();

            Assert.Equal("{\"section\":{\"foo\":\"bar\"}}", result);
        }

        [Fact]
        public void TestAddUniqueArg()
        {
            var header = new SmtpHeader();

            // Arrange
            header.AddUniqueArg(new Dictionary<string, string> { { "foo", "bar" } });

            // Actual
            var result = header.ToString();

            Assert.Equal("{\"unique_args\":{\"foo\":\"bar\"}}", result);
        }

        [Fact]
        public void TestAddCategory()
        {
            var header = new SmtpHeader();

            // Arrange
            header.AddCategory("foo");

            // Actual
            var result = header.ToString();

            Assert.Equal("{\"category\":\"foo\"}", result);
        }

        [Fact]
        public void TestAddCategories()
        {
            var header = new SmtpHeader();

            // Arrange
            header.AddCategory(new List<string> { "dogs", "animals", "pets", "mammals" });

            // Actual
            var result = header.ToString();

            Assert.Equal("{\"category\":[\"dogs\",\"animals\",\"pets\",\"mammals\"]}", result);
        }

        [Fact]
        public void TestBccFilter()
        {
            var header = new SmtpHeader();

            // Arrange
            header.UseBcc("foo@example.com");

            // Actual
            var result = header.ToString();

            Assert.Equal("{\"filters\":{\"bcc\":{\"settings\":{\"enable\":1,\"email\":\"foo@example.com\"}}}}", result);
        }

        [Fact]
        public void TestBypassListManagementFilter()
        {
            var header = new SmtpHeader();

            // Arrange
            header.UseBypassListManagement();

            // Actual
            var result = header.ToString();

            Assert.Equal("{\"filters\":{\"bypass_list_management\":{\"settings\":{\"enable\":1}}}}", result);
        }

        [Fact]
        public void TestClickTrackFilter()
        {
            var header = new SmtpHeader();

            // Arrange
            header.UseClickTrack();

            // Actual
            var result = header.ToString();

            Assert.Equal("{\"filters\":{\"clicktrack\":{\"settings\":{\"enable\":1}}}}", result);
        }

        [Fact]
        public void TestDkimFilter()
        {
            var header = new SmtpHeader();

            // Arrange
            header.UseDkim("example.com", false);

            // Actual
            var result = header.ToString();

            Assert.Equal("{\"filters\":{\"dkim\":{\"settings\":{\"domain\":\"example.com\",\"use_from\":false}}}}", result);
        }

        [Fact]
        public void TestDomainKeysFilter()
        {
            var header = new SmtpHeader();

            // Arrange
            header.UseDomainKeys("example.com", true);

            // Actual
            var result = header.ToString();

            Assert.Equal("{\"filters\":{\"domainkeys\":{\"settings\":{\"enable\":1,\"domain\":\"example.com\",\"sender\":true}}}}", result);
        }

        [Fact]
        public void TestFooterFilter()
        {
            var header = new SmtpHeader();

            // Arrange
            header.UseFooter("<p>html</p>", "text");

            // Actual
            var result = header.ToString();

            Assert.Equal("{\"filters\":{\"footer\":{\"settings\":{\"enable\":1,\"text/html\":\"<p>html</p>\",\"text/plain\":\"text\"}}}}", result);
        }

        [Fact]
        public void TestForwardSpamFilter()
        {
            var header = new SmtpHeader();

            // Arrange
            header.UseForwardSpam("you@example.com");

            // Actual
            var result = header.ToString();

            Assert.Equal("{\"filters\":{\"forwardspam\":{\"settings\":{\"enable\":1,\"email\":\"you@example.com\"}}}}", result);
        }

        [Fact]
        public void TestGoogleAnalyticsFilter()
        {
            var header = new SmtpHeader();

            // Arrange
            header.UseGoogleAnalytics("source", "medium", "term", "content", "campaign");

            // Actual
            var result = header.ToString();

            Assert.Equal("{\"filters\":{\"ganalytics\":{\"settings\":{\"enable\":1,\"utm_source\":\"source\",\"utm_medium\":\"medium\",\"utm_term\":\"term\",\"utm_content\":\"content\",\"utm_campaign\":\"campaign\"}}}}", result);
        }

        [Fact]
        public void TestGravatarFilter()
        {
            var header = new SmtpHeader();

            // Arrange
            header.UseGravatar();

            // Actual
            var result = header.ToString();

            Assert.Equal("{\"filters\":{\"gravatar\":{\"settings\":{\"enable\":1}}}}", result);
        }

        [Fact]
        public void TestOpenTrackFilter()
        {
            var header = new SmtpHeader();

            // Arrange
            header.UseOpenTrack();

            // Actual
            var result = header.ToString();

            Assert.Equal("{\"filters\":{\"opentrack\":{\"settings\":{\"enable\":1}}}}", result);
        }

        [Fact]
        public void TestSpamCheckFilter()
        {
            var header = new SmtpHeader();

            // Arrange
            header.UseSpamCheck(3.5, "http://example.com/");

            // Actual
            var result = header.ToString();

            Assert.Equal("{\"filters\":{\"spamcheck\":{\"settings\":{\"enable\":1,\"maxscore\":3.5,\"url\":\"http://example.com/\"}}}}", result);
        }

        [Fact]
        public void TestSubscriptionTrackFilter()
        {
            var header = new SmtpHeader();

            // Arrange
            header.UseSubscriptionTrack("<p>html</p>", "text", "replace");

            // Actual
            var result = header.ToString();

            Assert.Equal("{\"filters\":{\"subscriptiontrack\":{\"settings\":{\"enable\":1,\"text/html\":\"<p>html</p>\",\"text/plain\":\"text\",\"replace\":\"replace\"}}}}", result);
        }

        [Fact]
        public void TestTemplateEngineFilter()
        {
            var header = new SmtpHeader();

            // Arrange
            header.UseTemplateEngine("5997fcf6-2b9f-484d-acd5-7e9a99f0dc1f");

            // Actual
            var result = header.ToString();

            Assert.Equal("{\"filters\":{\"templates\":{\"settings\":{\"enable\":1,\"template_id\":\"5997fcf6-2b9f-484d-acd5-7e9a99f0dc1f\"}}}}", result);
        }

        [Fact]
        public void TestTemplateFilter()
        {
            var header = new SmtpHeader();

            // Arrange
            header.UseTemplate("<% body %>");

            // Actual
            var result = header.ToString();

            Assert.Equal("{\"filters\":{\"template\":{\"settings\":{\"enable\":1,\"text/html\":\"<% body %>\"}}}}", result);
        }
    }
}
