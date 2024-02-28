using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.ThamQuyenXuPhats;
using CatalogService.Application.Features.V1.ThamQuyenXuPhats.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ThamQuyenXuPhats.Commands.UpdateThamQuyenXuPhat;

public class UpdateThamQuyenXuPhatCommand : CreateOrUpdateCommand, IRequest<ApiResult<ThamQuyenXuPhatDto>>, IMapFrom<ThamQuyenXuPhat>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateThamQuyenXuPhatCommand, ThamQuyenXuPhat>().IgnoreAllNonExisting();
    }
}