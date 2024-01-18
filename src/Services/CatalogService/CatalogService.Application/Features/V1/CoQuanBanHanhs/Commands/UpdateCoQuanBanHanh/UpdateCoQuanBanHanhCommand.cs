using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.CoQuanBanHanhs;
using CatalogService.Application.Features.V1.CoQuanBanHanhs.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuanBanHanhs.Commands.UpdateCoQuanBanHanh;

public class UpdateCoQuanBanHanhCommand : CreateOrUpdateCommand, IRequest<ApiResult<CoQuanBanHanhDto>>, IMapFrom<CoQuanBanHanh>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateCoQuanBanHanhCommand, CoQuanBanHanh>().IgnoreAllNonExisting();
    }
}