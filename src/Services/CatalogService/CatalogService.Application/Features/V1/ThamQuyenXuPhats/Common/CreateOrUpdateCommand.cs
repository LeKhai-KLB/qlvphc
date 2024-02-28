using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.ThamQuyenXuPhats.Queries.GetThamQuyenXuPhats;
using CatalogService.Application.Parameters.ThamQuyenXuPhats;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Features.V1.ThamQuyenXuPhats.Common;

public class CreateOrUpdateCommand : IMapFrom<ThamQuyenXuPhat>
{
    public int DieuKhoanXuPhatId { get; set; }

    public string ThamQuyen { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrUpdateCommand, ThamQuyenXuPhat>();
        profile.CreateMap<GetThamQuyenXuPhatsQuery, ThamQuyenXuPhatParameter>();
    }
}