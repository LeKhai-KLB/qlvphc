﻿using IdentityService.Application.Common.Models.UserModels;
using MediatR;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Queries.GetUserbyId;

public class GetUserbyIdQuery : IRequest<ApiResult<UserDto>>
{
    public string Id { get; set; }

    public GetUserbyIdQuery(string id)
    {
        Id = id;
    }
}