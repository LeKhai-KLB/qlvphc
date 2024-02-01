using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.VanBanGiaiQuyets.Queries.GetPagedVanBanGiaiQuyetAsync;
using CatalogService.Application.Parameters.VanBanGiaiQuyets;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.VanBanGiaiQuyets.Common;

public class CreateOrUpdateCommand : IMapFrom<VanBanGiaiQuyet>
{
    public string MaGiayTo { get; set; }

    public string TheoNghiDinh { get; set; }

    public string TenGiayTo { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrUpdateCommand, VanBanGiaiQuyet>();
        profile.CreateMap<GetPagedVanBanGiaiQuyetQuery, VanBanGiaiQuyetParameter>();
    }
}