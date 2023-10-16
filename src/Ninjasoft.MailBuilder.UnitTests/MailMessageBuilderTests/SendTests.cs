using NUnit.Framework;

namespace Ninjasoft.MailBuilder.UnitTests.MailMessageBuilderTests
{
    [TestFixture]
    public class SendTests
    {
        [SetUp]
        public void Setup()
        {
            _smtpClient = new MockSmtpClient();
        }

        [Test]
        public void BodyTextIsSetCorrectly()
        {
            new MailMessageBuilder(_smtpClient)
                .AddBlankCarbonCopyRecipient("bcc@test.com")
                .AddCarbonCopyRecipient("cc@test.com")
                .AddRecipient("demo@test.com")
                .SetFrom("test@test.com")
                .SetBody("test email")
                .SetSubject("email subject")
                .Send();

            var mailMessage = _smtpClient.MailMessage;
            Assert.That(mailMessage.Bcc.Count, Is.EqualTo(1));
            Assert.That(mailMessage.Bcc[0].Address, Is.EqualTo("bcc@test.com"));
            Assert.That(mailMessage.CC.Count, Is.EqualTo(1));
            Assert.That(mailMessage.CC[0].Address, Is.EqualTo("cc@test.com"));
            Assert.That(mailMessage.To.Count, Is.EqualTo(1));
            Assert.That(mailMessage.To[0].Address, Is.EqualTo("demo@test.com"));
            Assert.That(mailMessage.From.Address, Is.EqualTo("test@test.com"));
            Assert.That(mailMessage.Subject, Is.EqualTo("email subject"));
            Assert.That(mailMessage.Body, Is.EqualTo("test email"));
            Assert.That(mailMessage.IsBodyHtml, Is.False);
        }


        private MockSmtpClient _smtpClient;
    }
}
