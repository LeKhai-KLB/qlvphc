using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.HinhThucXuPhatBoSungs;
using CatalogService.Application.Features.V1.HinhThucXuPhatBoSungs.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatBoSungs.Commands.UpdateHinhThucXuPhatBoSung;

public class UpdateHinhThucXuPhatBoSungCommand : CreateOrUpdateCommand, IRequest<ApiResult<HinhThucXuPhatBoSungDto>>, IMapFrom<HinhThucXuPhatBoSung>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateHinhThucXuPhatBoSungCommand, HinhThucXuPhatBoSung>()
            .IgnoreAllNonExisting();
    }
}