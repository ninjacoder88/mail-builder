using NSubstitute;
using NUnit.Framework;

namespace Ninjasoft.MailBuilder.UnitTests.MailMessageBuilderTests
{
    [TestFixture]
    public class SubjectTests
    {
        [SetUp]
        public void Setup()
        {
            _smtpClient = Substitute.For<ISmtpClient>();
        }

        [Test]
        public void SubjectIsSetCorrectly()
        {
            var mailMessage =
                new MailMessageBuilder(_smtpClient)
                .SetSubject("test email")
                .Build();

            Assert.That(mailMessage.Subject, Is.EqualTo("test email"));
        }

        [Test]
        public void SettingSubjectTwiceOverwrites()
        {
            var mailMessage =
                new MailMessageBuilder(_smtpClient)
                .SetSubject("demo email")
                .SetSubject("test email")
                .Build();

            Assert.That(mailMessage.Subject, Is.EqualTo("test email"));
        }

        private ISmtpClient _smtpClient;
    }
}
