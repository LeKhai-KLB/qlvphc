using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.ChiTietLinhVucXuPhats;
using CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Commands.UpdateChiTietLinhVucXuPhat;

public class UpdateChiTietLinhVucXuPhatCommand : CreateOrUpdateCommand, IRequest<ApiResult<ChiTietLinhVucXuPhatDto>>, IMapFrom<ChiTietLinhVucXuPhat>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateChiTietLinhVucXuPhatCommand, ChiTietLinhVucXuPhat>().IgnoreAllNonExisting();
    }
}