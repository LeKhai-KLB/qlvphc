using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.XaPhuongs;
using CatalogService.Application.Features.V1.XaPhuongs.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.XaPhuongs.Commands.UpdateXaPhuong;

public class UpdateXaPhuongCommand : CreateOrUpdateCommand, IRequest<ApiResult<XaPhuongDto>>, IMapFrom<XaPhuong>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateXaPhuongCommand, XaPhuong>()
            .IgnoreAllNonExisting();
    }
}