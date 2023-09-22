using System.Net.Mail;

namespace Ninjasoft.MailBuilder
{
    public class MailMessageBuilder : IMailMessageBuilder
    {
        public MailMessageBuilder() 
            : this(new SmtpClientProxy())
        {  
        }

        public MailMessageBuilder(ISmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
            _mailMessage = new MailMessage();
        }

        public IMailMessageBuilder AddBlankCarbonCopyRecipient(string address)
        {
            _mailMessage.Bcc.Add(address);
            return this;
        }

        public IMailMessageBuilder AddBlankCarbonCopyRecipient(string address, string displayName)
        {
            _mailMessage.Bcc.Add(new MailAddress(address, displayName));
            return this;
        }

        public IMailMessageBuilder AddCarbonCopyRecipient(string address)
        {
            _mailMessage.CC.Add(address);
            return this;
        }

        public IMailMessageBuilder AddCarbonCopyRecipient(string address, string displayName)
        {
            _mailMessage.CC.Add(new MailAddress(address, displayName));
            return this;
        }

        public IMailMessageBuilder AddRecipient(string address)
        {
            _mailMessage.To.Add(address);
            return this;
        }

        public IMailMessageBuilder AddRecipient(string address, string displayName)
        {
            _mailMessage.To.Add(new MailAddress(address, displayName));
            return this;
        }

        public MailMessage Build() => _mailMessage;

        public void Send()
        {
            using(var client = _smtpClient)
            {
                client.Send(_mailMessage);
            }
        }

        public async Task SendAsync()
        {
            using (var client = _smtpClient)
            {
                await client.SendMailAsync(_mailMessage);
            }
        }

        public IMailMessageBuilder SetFrom(string address)
        {
            _mailMessage.From = new MailAddress(address);
            return this;
        }

        public IMailMessageBuilder SetFrom(string address, string displayName)
        {
            _mailMessage.From = new MailAddress(address, displayName);
            return this;
        }

        public IMailMessageBuilder SetSubject(string subject)
        {
            _mailMessage.Subject = subject;
            return this;
        }

        public IMailMessageBuilder SetBody(string body, bool isHtml = false)
        {
            _mailMessage.Body = body;
            _mailMessage.IsBodyHtml = isHtml;
            return this;
        }

        private readonly MailMessage _mailMessage;
        private readonly ISmtpClient _smtpClient;
    }
}