using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.VanBanLienQuans.Queries.GetPagedByVanBanPhapLuatId;
using CatalogService.Application.Parameters.VanBanLienQuans;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.VanBanLienQuans.Common;

public class CreateOrUpdateCommand : IMapFrom<VanBanLienQuan>
{
    public int VanBanPhapLuatId { get; set; }

    public DateTime NgayBanHanh { get; set; }

    public string Ten { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrUpdateCommand, VanBanLienQuan>();
        profile.CreateMap<GetPagedByVanBanPhapLuatIdQuery, VanBanLienQuanParameter>();
    }
}