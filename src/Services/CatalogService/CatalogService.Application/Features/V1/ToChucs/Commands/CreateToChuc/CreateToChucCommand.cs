using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.ToChucs;
using CatalogService.Application.Features.V1.ToChucs.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ToChucs.Commands.CreateToChuc;

public class CreateToChucCommand : CreateOrUpdateCommand, IRequest<ApiResult<ToChucDto>>, IMapFrom<ToChuc>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateToChucDto, CreateToChucCommand>();
        profile.CreateMap<CreateToChucCommand, ToChuc>();
    }
}