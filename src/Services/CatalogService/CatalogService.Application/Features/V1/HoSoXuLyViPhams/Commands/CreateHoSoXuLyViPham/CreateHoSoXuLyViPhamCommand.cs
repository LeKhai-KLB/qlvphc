using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using CatalogService.Application.Features.V1.HoSoXuLyViPhams.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HoSoXuLyViPhams.Commands.CreateHoSoXuLyViPham;

public class CreateHoSoXuLyViPhamCommand : CreateOrUpdateCommand, IRequest<ApiResult<HoSoXuLyViPhamDto>>, IMapFrom<HoSoXuLyViPham>
{
    public int[]? VanBanGiaiQuyetIds { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateHoSoXuLyViPhamDto, CreateHoSoXuLyViPhamCommand>();
        profile.CreateMap<CreateHoSoXuLyViPhamCommand, HoSoXuLyViPham>();
    }
}