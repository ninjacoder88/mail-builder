using System.Net.Mail;

namespace Ninjasoft.MailBuilder
{
    public interface ISmtpClient : IDisposable
    {
        void Send(MailMessage message);

        Task SendMailAsync(MailMessage message);
    }
}
