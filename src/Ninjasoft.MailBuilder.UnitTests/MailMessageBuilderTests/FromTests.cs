using NSubstitute;
using NUnit.Framework;

namespace Ninjasoft.MailBuilder.UnitTests.MailMessageBuilderTests
{
    [TestFixture]
    public class FromTests
    {
        [SetUp]
        public void Setup()
        {
            _smtpClient = Substitute.For<ISmtpClient>();
        }

        [Test]
        public void FromIsSetCorrectly()
        {
            var mailMessage =
                new MailMessageBuilder(_smtpClient)
                .SetFrom("demo@test.com")
                .Build();

            Assert.That(mailMessage.From.Address, Is.EqualTo("demo@test.com"));
        }

        [Test]
        public void FromWithDisplayNameIsSetCorrectly()
        {
            var mailMessage =
                new MailMessageBuilder(_smtpClient)
                .SetFrom("demo@test.com", "Demo User")
                .Build();

            Assert.That(mailMessage.From.DisplayName, Is.EqualTo("Demo User"));
        }

        [Test]
        public void CallingFromTwiceOverwrites()
        {
            var mailMessage =
                new MailMessageBuilder(_smtpClient)
                .SetFrom("test@test.com", "Test User")
                .SetFrom("demo@test.com", "Demo User")
                .Build();

            Assert.That(mailMessage.From.DisplayName, Is.EqualTo("Demo User"));
        }

        private ISmtpClient _smtpClient;
    }
}
