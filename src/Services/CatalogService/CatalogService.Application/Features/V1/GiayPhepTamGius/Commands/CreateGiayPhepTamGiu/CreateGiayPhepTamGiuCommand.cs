using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.GiayPhepTamGius;
using CatalogService.Application.Features.V1.GiayPhepTamGius.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;
using GiayPhepTamGiuDto = CatalogService.Application.Common.Models.GiayPhepTamGius.GiayPhepTamGiuDto;

namespace CatalogService.Application.Features.V1.GiayPhepTamGius.Commands.CreateGiayPhepTamGiu
{
    public class CreateGiayPhepTamGiuCommand : CreateOrUpdateCommand, IRequest<ApiResult<GiayPhepTamGiuDto>>, IMapFrom<GiayPhepTamGiu>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateGiayPhepTamGiuDto, CreateGiayPhepTamGiuCommand>();
            profile.CreateMap<CreateGiayPhepTamGiuCommand, GiayPhepTamGiu>();
        }
    }
}