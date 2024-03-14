using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using CatalogService.Application.Features.V1.HoSoXuLyViPhams.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HoSoXuLyViPhams.Commands.UpdateHoSoXuLyViPham;

public class UpdateHoSoXuLyViPhamCommand : CreateOrUpdateCommand, IRequest<ApiResult<HoSoXuLyViPhamDto>>, IMapFrom<HoSoXuLyViPham>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateHoSoXuLyViPhamCommand, HoSoXuLyViPham>().IgnoreAllNonExisting();
    }
}