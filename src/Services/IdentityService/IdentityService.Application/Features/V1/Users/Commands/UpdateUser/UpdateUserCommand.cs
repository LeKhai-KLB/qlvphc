using AutoMapper;
using IdentityService.Application.Common.Mappings;
using IdentityService.Application.Common.Models.UserModels;
using IdentityService.Application.Features.V1.Users.Common;
using IdentityService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Commands.UpdateUser;

public class UpdateUserCommand : CreateOrUpdateCommand, IRequest<ApiResult<UserDto>>, IMapFrom<User>
{
    public Guid Id { get; private set; }

    public void SetId(Guid id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateUserCommand, User>().IgnoreAllNonExisting();
    }
}