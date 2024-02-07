using AutoMapper;
using IdentityService.Application.Common.Mappings;
using IdentityService.Domain.Entities;
using Shared.Common.Constants;

namespace IdentityService.Application.Common.Models.UserModels;

public class UserDto : IMapFrom<User>
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

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserDto>().ReverseMap();
    }
}