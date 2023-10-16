using NSubstitute;
using NUnit.Framework;

namespace Ninjasoft.MailBuilder.UnitTests.MailMessageBuilderTests
{
    [TestFixture]
    public class BodyTests
    {
        [SetUp]
        public void Setup()
        {
            _smtpClient = Substitute.For<ISmtpClient>();
        }

        [Test]
        public void BodyTextIsSetCorrectly()
        {
            var mailMessage =
                new MailMessageBuilder(_smtpClient)
                .SetBody("test email")
                .Build();

            Assert.That(mailMessage.Body, Is.EqualTo("test email"));
            Assert.That(mailMessage.IsBodyHtml, Is.False);
        }

        [Test]
        public void BodyHtmlIsSetCorrectly()
        {
            var mailMessage =
                new MailMessageBuilder(_smtpClient)
                .SetBody("test email", true)
                .Build();

            Assert.That(mailMessage.Body, Is.EqualTo("test email"));
            Assert.That(mailMessage.IsBodyHtml, Is.True);
        }

        [Test]
        public void SettingBodyTwiceOverwrites()
        {
            var mailMessage =
                new MailMessageBuilder(_smtpClient)
                .SetBody("demo email", true)
                .SetBody("test email", true)
                .Build();

            Assert.That(mailMessage.Body, Is.EqualTo("test email"));
            Assert.That(mailMessage.IsBodyHtml, Is.True);
        }

        private ISmtpClient _smtpClient;
    }
}
