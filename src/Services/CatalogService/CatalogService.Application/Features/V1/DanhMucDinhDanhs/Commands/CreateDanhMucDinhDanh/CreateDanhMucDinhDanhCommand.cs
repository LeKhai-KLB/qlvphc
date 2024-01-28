using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.DanhMucDinhDanhs;
using CatalogService.Application.Features.V1.DanhMucDinhDanhs.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;
using DanhMucDinhDanhDto = CatalogService.Application.Common.Models.DanhMucDinhDanhs.DanhMucDinhDanhDto;

namespace CatalogService.Application.Features.V1.DanhMucDinhDanhs.Commands.CreateDanhMucDinhDanh
{
    public class CreateDanhMucDinhDanhCommand : CreateOrUpdateCommand, IRequest<ApiResult<DanhMucDinhDanhDto>>, IMapFrom<DanhMucDinhDanh>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDanhMucDinhDanhDto, CreateDanhMucDinhDanhCommand>();
            profile.CreateMap<CreateDanhMucDinhDanhCommand, DanhMucDinhDanh>();
        }
    }
}