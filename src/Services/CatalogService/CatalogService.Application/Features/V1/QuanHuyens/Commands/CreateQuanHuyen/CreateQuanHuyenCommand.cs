using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.QuanHuyens;
using CatalogService.Application.Features.V1.QuanHuyens.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;
using QuanHuyenDto = CatalogService.Application.Common.Models.QuanHuyens.QuanHuyenDto;

namespace CatalogService.Application.Features.V1.QuanHuyens.Commands.CreateQuanHuyen
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