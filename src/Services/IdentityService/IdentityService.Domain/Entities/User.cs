using Microsoft.AspNetCore.Identity;

namespace IdentityService.Domain.Entities
{
    public class User : IdentityUser
    {
        public DateTime? NgaySinh { get; set; }

        public string? CCCD { get; set; }
    }
}