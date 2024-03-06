using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.HinhThucXuPhatBoSungs;
using CatalogService.Application.Features.V1.HinhThucXuPhatBoSungs.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;
using HinhThucXuPhatBoSungDto = CatalogService.Application.Common.Models.HinhThucXuPhatBoSungs.HinhThucXuPhatBoSungDto;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatBoSungs.Commands.CreateHinhThucXuPhatBoSung
{
    public class CreateHinhThucXuPhatBoSungCommand : CreateOrUpdateCommand, IRequest<ApiResult<HinhThucXuPhatBoSungDto>>, IMapFrom<HinhThucXuPhatBoSung>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateHinhThucXuPhatBoSungDto, CreateHinhThucXuPhatBoSungCommand>();
            profile.CreateMap<CreateHinhThucXuPhatBoSungCommand, HinhThucXuPhatBoSung>();
        }
    }
}