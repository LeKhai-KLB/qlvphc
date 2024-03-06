using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.TangVatPhuongTienTamGius;
using CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;
using TangVatPhuongTienTamGiuDto = CatalogService.Application.Common.Models.TangVatPhuongTienTamGius.TangVatPhuongTienTamGiuDto;

namespace CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Commands.CreateTangVatPhuongTienTamGiu
{
    public class CreateTangVatPhuongTienTamGiuCommand : CreateOrUpdateCommand, IRequest<ApiResult<TangVatPhuongTienTamGiuDto>>, IMapFrom<TangVatPhuongTienTamGiu>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTangVatPhuongTienTamGiuDto, CreateTangVatPhuongTienTamGiuCommand>();
            profile.CreateMap<CreateTangVatPhuongTienTamGiuCommand, TangVatPhuongTienTamGiu>();
        }
    }
}