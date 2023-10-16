using NSubstitute;
using NUnit.Framework;

namespace Ninjasoft.MailBuilder.UnitTests.MailMessageBuilderTests
{
    [TestFixture]
    public class CarbonCopyTests
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
                .AddCarbonCopyRecipient("cc@test.com")
                .Build();

            Assert.That(mailMessage.CC.Count, Is.EqualTo(1));
            Assert.That(mailMessage.CC[0].Address, Is.EqualTo("cc@test.com"));
        }

        [Test]
        public void CcWithDisplayIsAdded()
        {
            var mailMessage =
                new MailMessageBuilder(_smtpClient)
                .AddCarbonCopyRecipient("cc@test.com", "Carbon Copy")
                .Build();

            Assert.That(mailMessage.CC.Count, Is.EqualTo(1));
            Assert.That(mailMessage.CC[0].Address, Is.EqualTo("cc@test.com"));
            Assert.That(mailMessage.CC[0].DisplayName, Is.EqualTo("Carbon Copy"));
        }

        [Test]
        public void CcsAreAdded()
        {
            var mailMessage =
                new MailMessageBuilder(_smtpClient)
                .AddCarbonCopyRecipient("cc1@test.com")
                .AddCarbonCopyRecipient("cc2@test.com")
                .Build();

            Assert.That(mailMessage.CC.Count, Is.EqualTo(2));
            Assert.That(mailMessage.CC[0].Address, Is.EqualTo("cc1@test.com"));
            Assert.That(mailMessage.CC[1].Address, Is.EqualTo("cc2@test.com"));
        }

        private ISmtpClient _smtpClient;
    }
}
