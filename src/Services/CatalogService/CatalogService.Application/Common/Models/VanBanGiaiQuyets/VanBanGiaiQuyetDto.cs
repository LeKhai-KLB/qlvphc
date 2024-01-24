using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Models.VanBanGiaiQuyets;

public class VanBanGiaiQuyetDto : IMapFrom<VanBanGiaiQuyet>
{
    public int Id { get; set; }

    public string MaGiayTo { get; set; }

    public string TheoNghiDinh { get; set; }

    public string TenGiayTo { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<VanBanGiaiQuyet, VanBanGiaiQuyetDto>().ReverseMap();
    }
}