using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.DieuKhoanXuPhats.Queries.GetDieuKhoanXuPhats;
using CatalogService.Application.Parameters.DieuKhoanXuPhats;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.DieuKhoanXuPhats.Common;

public class CreateOrUpdateCommand : IMapFrom<DieuKhoanXuPhat>
{
    public int LinhVucXuPhatId { get; set; }
    public string Dieu { get; set; }
    public string Khoan { get; set; }
    public string Diem { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrUpdateCommand, DieuKhoanXuPhat>();
        profile.CreateMap<GetDieuKhoanXuPhatsQuery, DieuKhoanXuPhatParameter>();
    }
}