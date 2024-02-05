using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.LinhVucXuPhats.Queries.GetPagedLinhVucXuPhatAsync;
using CatalogService.Application.Parameters.LinhVucXuPhats;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.LinhVucXuPhats.Common;

public class CreateOrUpdateCommand : IMapFrom<LinhVucXuPhat>
{
    public string TenLinhVuc { get; set; }

    public string NhomLinhVuc { get; set; }

    public string NghiDinh { get; set; }

    public string HanhVi_QuyetDinh { get; set; }

    public string DanChungNghiDinh { get; set; }

    public bool HienThi { get; set; }

    public bool HetHieuLuc { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrUpdateCommand, LinhVucXuPhat>();
        profile.CreateMap<GetPagedLinhVucXuPhatQuery, LinhVucXuPhatParameter>();
    }
}