using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.HinhThucXuPhatChinhs;
using CatalogService.Application.Features.V1.HinhThucXuPhatChinhs.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;
using HinhThucXuPhatChinhDto = CatalogService.Application.Common.Models.HinhThucXuPhatChinhs.HinhThucXuPhatChinhDto;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatChinhs.Commands.CreateHinhThucXuPhatChinh
{
    public class CreateHinhThucXuPhatChinhCommand : CreateOrUpdateCommand, IRequest<ApiResult<HinhThucXuPhatChinhDto>>, IMapFrom<HinhThucXuPhatChinh>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateHinhThucXuPhatChinhDto, CreateHinhThucXuPhatChinhCommand>();
            profile.CreateMap<CreateHinhThucXuPhatChinhCommand, HinhThucXuPhatChinh>();
        }
    }
}