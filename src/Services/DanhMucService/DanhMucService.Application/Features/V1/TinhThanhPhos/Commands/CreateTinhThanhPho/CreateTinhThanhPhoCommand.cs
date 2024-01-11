using AutoMapper;
using DanhMucService.Application.Common.Mappings;
using DanhMucService.Application.Common.Models.TinhThanhPhos;
using DanhMucService.Application.Features.V1.TinhThanhPhos.Common;
using DanhMucService.Domain.Entities;
using MediatR;
using Shared.SeedWord;
using TinhThanhPhoDto = DanhMucService.Application.Common.Models.TinhThanhPhos.TinhThanhPhoDto;

namespace DanhMucService.Application.Features.V1.TinhThanhPhos.Commands.CreateTinhThanhPho
{
    public class CreateTinhThanhPhoCommand : CreateOrUpdateCommand, IRequest<ApiResult<TinhThanhPhoDto>>, IMapFrom<TinhThanhPho>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTinhThanhPhoDto, CreateTinhThanhPhoCommand>();
            profile.CreateMap<CreateTinhThanhPhoCommand, TinhThanhPho>();
        }
    }
}