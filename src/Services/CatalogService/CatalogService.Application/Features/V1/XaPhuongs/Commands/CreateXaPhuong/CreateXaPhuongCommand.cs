using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.XaPhuongs;
using CatalogService.Application.Features.V1.XaPhuongs.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;
using XaPhuongDto = CatalogService.Application.Common.Models.XaPhuongs.XaPhuongDto;

namespace CatalogService.Application.Features.V1.XaPhuongs.Commands.CreateXaPhuong
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