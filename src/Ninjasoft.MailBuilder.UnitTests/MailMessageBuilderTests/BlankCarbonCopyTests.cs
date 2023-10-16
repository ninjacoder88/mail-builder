using NSubstitute;
using NUnit.Framework;

namespace Ninjasoft.MailBuilder.UnitTests.MailMessageBuilderTests
{
    [TestFixture]
    public class BlankCarbonCopyTests
    {
        [SetUp]
        public void Setup()
        {
            _smtpClient = Substitute.For<ISmtpClient>();
        }

        [Test]
        public void BccIsAdded()
        {
            var mailMessage =
                new MailMessageBuilder(_smtpClient)
                .AddBlankCarbonCopyRecipient("bcc@test.com")
                .Build();

            Assert.That(mailMessage.Bcc.Count, Is.EqualTo(1));
            Assert.That(mailMessage.Bcc[0].Address, Is.EqualTo("bcc@test.com"));
        }

        [Test]
        public void BccWithDisplayIsAdded()
        {
            var mailMessage =
                new MailMessageBuilder(_smtpClient)
                .AddBlankCarbonCopyRecipient("bcc@test.com", "Blank Carbon Copy")
                .Build();

            Assert.That(mailMessage.Bcc.Count, Is.EqualTo(1));
            Assert.That(mailMessage.Bcc[0].Address, Is.EqualTo("bcc@test.com"));
            Assert.That(mailMessage.Bcc[0].DisplayName, Is.EqualTo("Blank Carbon Copy"));
        }

        [Test]
        public void BccsAreAdded()
        {
            var mailMessage =
                new MailMessageBuilder(_smtpClient)
                .AddBlankCarbonCopyRecipient("bcc1@test.com")
                .AddBlankCarbonCopyRecipient("bcc2@test.com")
                .Build();

            Assert.That(mailMessage.Bcc.Count, Is.EqualTo(2));
            Assert.That(mailMessage.Bcc[0].Address, Is.EqualTo("bcc1@test.com"));
            Assert.That(mailMessage.Bcc[1].Address, Is.EqualTo("bcc2@test.com"));
        }

        private ISmtpClient _smtpClient;
    }
}
