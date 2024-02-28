using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Models.LinhVucXuPhats;

public class LinhVucXuPhatDto : IMapFrom<LinhVucXuPhat>
{
    public int Id { get; set; }

    public string TenLinhVuc { get; set; }

    public string NhomLinhVuc { get; set; }

    public string NghiDinh { get; set; }

    public string? HanhVi_QuyetDinh { get; set; }

    public string? DanChungNghiDinh { get; set; }

    public bool HienThi { get; set; }

    public bool HetHieuLuc { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<LinhVucXuPhat, LinhVucXuPhatDto>().ReverseMap();
    }
}