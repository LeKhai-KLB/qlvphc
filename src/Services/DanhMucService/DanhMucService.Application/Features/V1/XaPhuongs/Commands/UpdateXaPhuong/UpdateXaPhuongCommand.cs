using AutoMapper;
using DanhMucService.Application.Common.Mappings;
using DanhMucService.Application.Common.Models.XaPhuongs;
using DanhMucService.Application.Features.V1.XaPhuongs.Common;
using DanhMucService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace DanhMucService.Application.Features.V1.XaPhuongs.Commands.UpdateXaPhuong;

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