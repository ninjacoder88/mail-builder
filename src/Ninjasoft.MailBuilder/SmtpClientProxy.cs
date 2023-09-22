using System.Net.Mail;

namespace Ninjasoft.MailBuilder
{
    public class SmtpClientProxy : ISmtpClient
    {
        public SmtpClientProxy()
        {
            _smtpClient = new SmtpClient();
        }

        public SmtpClientProxy(string? host)
        {
            _smtpClient = new SmtpClient(host);
        }

        public SmtpClientProxy(string? host, int port)
        {
            _smtpClient = new SmtpClient(host, port);
        }

        public void Dispose()
        {
            _smtpClient.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Send(MailMessage message)
        {
            _smtpClient.Send(message);
        }

        public Task SendMailAsync(MailMessage message)
        {
            return _smtpClient.SendMailAsync(message);
        }

        private readonly SmtpClient _smtpClient;
    }
}
