using IdentityService.Application.Common.Models;

namespace IdentityService.Application.Common.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}