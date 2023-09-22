using AutoFixture;
using NSubstitute;
using NUnit.Framework;

namespace Ninjasoft.MailBuilder.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _smtpClient = Substitute.For<ISmtpClient>();
        }

        [Test]
        public void Test1()
        {
            new MailMessageBuilder(_smtpClient)
                .SetFrom("demo@test.com")
                .AddRecipient("test@test.com")
                .SetSubject("test email")
                .SetBody("test email")
                .Send();
        }

        private Fixture _fixture;
        private ISmtpClient _smtpClient;
    }
}