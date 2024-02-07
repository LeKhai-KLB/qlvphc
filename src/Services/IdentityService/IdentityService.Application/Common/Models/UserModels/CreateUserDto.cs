using Shared.Common.Constants;

namespace IdentityService.Application.Common.Models.UserModels;

public class CreateUserDto
{
    public string Username { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }

    public string PhoneNumber { get; set; }

    public string Role { get; set; }

    public string HoTen { get; set; }

    public DateTime NgaySinh { get; set; }

    public string CCCD { get; set; }

    public Genders GioiTinh { get; set; }

    public string DiaChi { get; set; }

    public string GhiChu { get; set; }
}