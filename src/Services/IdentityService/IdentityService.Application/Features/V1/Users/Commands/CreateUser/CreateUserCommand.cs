using AutoMapper;
using IdentityService.Application.Common.Mappings;
using IdentityService.Application.Common.Models.UserModels;
using IdentityService.Application.Features.V1.Users.Common;
using IdentityService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Commands.CreateUser;

public class CreateUserCommand : CreateOrUpdateCommand, IRequest<ApiResult<UserDto>>, IMapFrom<User>
{
    public string Password { get; set; }

    public string ConfirmPassword { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateUserDto, CreateUserCommand>();
        profile.CreateMap<CreateUserCommand, User>();
    }
}