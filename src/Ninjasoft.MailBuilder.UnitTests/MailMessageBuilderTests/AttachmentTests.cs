using NSubstitute;
using NUnit.Framework;
using System.IO;
using System.Net.Mail;

namespace Ninjasoft.MailBuilder.UnitTests.MailMessageBuilderTests
{
    public class AttachmentTests
    {
        [SetUp]
        public void Setup()
        {
            _smtpClient = Substitute.For<ISmtpClient>();
        }

        [Test]
        public void BccIsAdded()
        {
            Attachment attachment;
            
            using(var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(ms))
                {
                    sw.WriteLine("file line");
                }
                attachment = new Attachment(ms, "text/plain");
            }

            var mailMessage =
                new MailMessageBuilder(_smtpClient)
                .AddAttachment(attachment)
                .Build();

            Assert.That(mailMessage.Attachments.Count, Is.EqualTo(1));
        }

        private ISmtpClient _smtpClient;
    }
}
