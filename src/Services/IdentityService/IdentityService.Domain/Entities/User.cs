using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shared.Common.Constants;

namespace IdentityService.Domain.Entities
{
    public class User : IdentityUser
    {
        [Column(TypeName = "nvarchar(255)")]
        public string? HoTen { get; set; }

        public DateTime NgaySinh { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? CCCD { get; set; }

        public Genders GioiTinh { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        public string? DiaChi { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        public string? GhiChu { get; set; }
    }
}