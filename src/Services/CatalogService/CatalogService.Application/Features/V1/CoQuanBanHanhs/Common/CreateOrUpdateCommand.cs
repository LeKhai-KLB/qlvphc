using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.CoQuanBanHanhs.Queries.GetPagedCoQuanBanHanhAsync;
using CatalogService.Application.Parameters.CoQuanBanHanhs;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.CoQuanBanHanhs.Common;

public class CreateOrUpdateCommand : IMapFrom<CoQuanBanHanh>
{
    public string NhomCoQuan { get; set; }

    public string TenCoQuan { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrUpdateCommand, CoQuanBanHanh>();
        profile.CreateMap<GetPagedCoQuanBanHanhQuery, CoQuanBanHanhParameter>();
    }
}