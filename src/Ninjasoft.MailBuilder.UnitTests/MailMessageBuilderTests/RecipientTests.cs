using NSubstitute;
using NUnit.Framework;

namespace Ninjasoft.MailBuilder.UnitTests.MailMessageBuilderTests
{
    [TestFixture]
    public class RecipientTests
    {
        [SetUp]
        public void Setup()
        {
            _smtpClient = Substitute.For<ISmtpClient>();
        }

        [Test]
        public void CcIsAdded()
        {
            var mailMessage =
                new MailMessageBuilder(_smtpClient)
                .AddRecipient("test@test.com")
                .Build();

            Assert.That(mailMessage.To.Count, Is.EqualTo(1));
            Assert.That(mailMessage.To[0].Address, Is.EqualTo("test@test.com"));
        }

        [Test]
        public void CcWithDisplayIsAdded()
        {
            var mailMessage =
                new MailMessageBuilder(_smtpClient)
                .AddRecipient("test@test.com", "Test")
                .Build();

            Assert.That(mailMessage.To.Count, Is.EqualTo(1));
            Assert.That(mailMessage.To[0].Address, Is.EqualTo("test@test.com"));
            Assert.That(mailMessage.To[0].DisplayName, Is.EqualTo("Test"));
        }

        [Test]
        public void CcsAreAdded()
        {
            var mailMessage =
                new MailMessageBuilder(_smtpClient)
                .AddRecipient("test1@test.com")
                .AddRecipient("test2@test.com")
                .Build();

            Assert.That(mailMessage.To.Count, Is.EqualTo(2));
            Assert.That(mailMessage.To[0].Address, Is.EqualTo("test1@test.com"));
            Assert.That(mailMessage.To[1].Address, Is.EqualTo("test2@test.com"));
        }

        private ISmtpClient _smtpClient;
    }
}
