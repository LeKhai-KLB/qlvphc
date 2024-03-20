using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.ToChucs;
using CatalogService.Application.Features.V1.ToChucs.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;
using Infrastructure.Mappings;

namespace CatalogService.Application.Features.V1.ToChucs.Commands.UpdateToChuc;

public class UpdateToChucCommand : CreateOrUpdateCommand, IRequest<ApiResult<ToChucDto>>, IMapFrom<ToChuc>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateToChucCommand, ToChuc>().IgnoreAllNonExisting();
    }
}