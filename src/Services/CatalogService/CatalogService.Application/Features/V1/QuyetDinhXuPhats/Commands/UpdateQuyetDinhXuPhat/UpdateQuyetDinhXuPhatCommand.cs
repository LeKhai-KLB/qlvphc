using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.QuyetDinhXuPhats;
using CatalogService.Application.Features.V1.QuyetDinhXuPhats.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.QuyetDinhXuPhats.Commands.UpdateQuyetDinhXuPhat;

public class UpdateQuyetDinhXuPhatCommand : CreateOrUpdateCommand, IRequest<ApiResult<QuyetDinhXuPhatDto>>, IMapFrom<QuyetDinhXuPhat>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateQuyetDinhXuPhatCommand, QuyetDinhXuPhat>()
            .IgnoreAllNonExisting();
    }
}