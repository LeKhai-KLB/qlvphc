using Microsoft.AspNetCore.Identity;

namespace IdentityService.API.Models
{
    public class User : IdentityUser
    {
        public string? UserId { get; set; }
        public string? PhoneNo { get; set; }
    }
}