using AutoMapper;
using DanhMucService.Application.Common.Mappings;
using DanhMucService.Application.Common.Models.QuanHuyens;
using DanhMucService.Application.Features.V1.QuanHuyens.Common;
using DanhMucService.Domain.Entities;
using MediatR;
using Shared.SeedWord;
using QuanHuyenDto = DanhMucService.Application.Common.Models.QuanHuyens.QuanHuyenDto;

namespace DanhMucService.Application.Features.V1.QuanHuyens.Commands.CreateQuanHuyen
{
    public class CreateQuanHuyenCommand : CreateOrUpdateCommand, IRequest<ApiResult<QuanHuyenDto>>, IMapFrom<QuanHuyen>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateQuanHuyenDto, CreateQuanHuyenCommand>();
            profile.CreateMap<CreateQuanHuyenCommand, QuanHuyen>();
        }
    }
}