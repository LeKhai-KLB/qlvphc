using IdentityService.Domain.Entities;
using MediatR;
using Shared.Common.Constants;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<ApiResult<User>>
{
    public string Id { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string HoTen { get; set; }

    public DateTime NgaySinh { get; set; }

    public string CCCD { get; set; }

    public Genders GioiTinh { get; set; }

    public string DiaChi { get; set; }

    public string GhiChu { get; set; }
}