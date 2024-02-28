using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.ThamQuyenXuPhats;
using CatalogService.Application.Features.V1.ThamQuyenXuPhats.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ThamQuyenXuPhats.Commands.CreateThamQuyenXuPhat;

public class CreateThamQuyenXuPhatCommand : CreateOrUpdateCommand, IRequest<ApiResult<ThamQuyenXuPhatDto>>, IMapFrom<ThamQuyenXuPhat>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateThamQuyenXuPhatDto, CreateThamQuyenXuPhatCommand>();
        profile.CreateMap<CreateThamQuyenXuPhatCommand, ThamQuyenXuPhat>();
    }
}