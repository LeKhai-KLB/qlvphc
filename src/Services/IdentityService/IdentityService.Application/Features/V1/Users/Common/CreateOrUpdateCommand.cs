using AutoMapper;
using IdentityService.Application.Common.Mappings;
using IdentityService.Application.Features.V1.Users.Queries.GetUsers;
using IdentityService.Application.Parameters.Users;
using IdentityService.Domain.Entities;
using Shared.Common.Constants;

namespace IdentityService.Application.Features.V1.Users.Common;

public class CreateOrUpdateCommand : IMapFrom<User>
{
    public string? UserName { get; set; }

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
        profile.CreateMap<CreateOrUpdateCommand, User>();
        profile.CreateMap<GetUsersQuery, UserParameter>();
    }
}