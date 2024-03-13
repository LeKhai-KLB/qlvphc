using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.CoQuans;
using CatalogService.Application.Features.V1.CoQuans.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuans.Commands.UpdateCoQuan;

public class UpdateCoQuanCommand : CreateOrUpdateCommand, IRequest<ApiResult<CoQuanDto>>, IMapFrom<CoQuan>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateCoQuanCommand, CoQuan>().IgnoreAllNonExisting();
    }
}