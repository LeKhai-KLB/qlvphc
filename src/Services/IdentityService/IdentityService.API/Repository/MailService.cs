using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Text;
using IdentityService.API.Services;
using IdentityService.API.Models;
using MailKit.Net.Smtp;

namespace IdentityService.API.Repository
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _config;
        private readonly MailSettings _mailSettings;

        public MailService(IConfiguration configuration, IOptions<MailSettings> mailSettings)
        {
            _config = configuration;
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }

            var password = Encoding.UTF8.GetString(Convert.FromBase64String(_mailSettings.Password));

            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}