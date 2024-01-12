using IdentityService.API.Models;

namespace IdentityService.API.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}