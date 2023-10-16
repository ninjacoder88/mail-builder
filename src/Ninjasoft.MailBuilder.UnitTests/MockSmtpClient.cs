using System.Net.Mail;
using System.Threading.Tasks;

namespace Ninjasoft.MailBuilder.UnitTests
{
    internal class MockSmtpClient : ISmtpClient
    {
        public MailMessage MailMessage { get; private set; }

        public void Dispose()
        {
        }

        public void Send(MailMessage message)
        {
            MailMessage = message;
        }

        public Task SendMailAsync(MailMessage message)
        {
            MailMessage = message;
            return Task.CompletedTask;
        }
    }
}
