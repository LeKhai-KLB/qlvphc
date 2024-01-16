using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.ChiTietLinhVucXuPhats;
using CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Commands.CreateChiTietLinhVucXuPhat;

public class CreateChiTietLinhVucXuPhatCommand : CreateOrUpdateCommand, IRequest<ApiResult<ChiTietLinhVucXuPhatDto>>, IMapFrom<ChiTietLinhVucXuPhat>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateChiTietLinhVucXuPhatDto, CreateChiTietLinhVucXuPhatCommand>();
        profile.CreateMap<CreateChiTietLinhVucXuPhatCommand, ChiTietLinhVucXuPhat>();
    }
}