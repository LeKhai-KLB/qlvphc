using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.TangVatPhuongTienTamGius;
using CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Commands.UpdateTangVatPhuongTienTamGiu;

public class UpdateTangVatPhuongTienTamGiuCommand : CreateOrUpdateCommand, IRequest<ApiResult<TangVatPhuongTienTamGiuDto>>, IMapFrom<TangVatPhuongTienTamGiu>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateTangVatPhuongTienTamGiuCommand, TangVatPhuongTienTamGiu>()
            .IgnoreAllNonExisting();
    }
}