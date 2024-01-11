using AutoMapper;
using DanhMucService.Application.Common.Mappings;
using DanhMucService.Application.Common.Models.XaPhuongs;
using DanhMucService.Application.Features.V1.XaPhuongs.Common;
using DanhMucService.Domain.Entities;
using MediatR;
using Shared.SeedWord;
using XaPhuongDto = DanhMucService.Application.Common.Models.XaPhuongs.XaPhuongDto;

namespace DanhMucService.Application.Features.V1.XaPhuongs.Commands.CreateXaPhuong
{
    public class CreateXaPhuongCommand : CreateOrUpdateCommand, IRequest<ApiResult<XaPhuongDto>>, IMapFrom<XaPhuong>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateXaPhuongDto, CreateXaPhuongCommand>();
            profile.CreateMap<CreateXaPhuongCommand, XaPhuong>();
        }
    }
}