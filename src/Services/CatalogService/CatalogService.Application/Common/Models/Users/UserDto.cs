using Shared.Common.Constants;

namespace CatalogService.Application.Common.Models.Users;

public class UserDto
{
    public Guid Id { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string Role { get; set; }

    public string HoTen { get; set; }

    public DateTime NgaySinh { get; set; }

    public string CCCD { get; set; }

    public Genders GioiTinh { get; set; }

    public string DiaChi { get; set; }

    public string GhiChu { get; set; }
}