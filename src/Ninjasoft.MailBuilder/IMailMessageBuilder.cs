using System.Net.Mail;

namespace Ninjasoft.MailBuilder
{
    public interface IMailMessageBuilder
    {
        IMailMessageBuilder AddAttachment(Attachment attachment);

        IMailMessageBuilder AddAttachment(string fileName);

        IMailMessageBuilder AddBlankCarbonCopyRecipient(string address);

        IMailMessageBuilder AddBlankCarbonCopyRecipient(string address, string displayName);

        IMailMessageBuilder AddCarbonCopyRecipient(string address);

        IMailMessageBuilder AddCarbonCopyRecipient(string address, string displayName);

        IMailMessageBuilder AddRecipient(string address);

        IMailMessageBuilder AddRecipient(string address, string displayName);

        MailMessage Build();

        void Send();

        Task SendAsync();

        IMailMessageBuilder SetFrom(string address);

        IMailMessageBuilder SetFrom(string address, string displayName);

        IMailMessageBuilder SetSubject(string subject);

        IMailMessageBuilder SetBody(string body, bool isHtml = false);
    }
}
