using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.GiayPhepTamGius;
using CatalogService.Application.Features.V1.GiayPhepTamGius.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.GiayPhepTamGius.Commands.UpdateGiayPhepTamGiu;

public class UpdateGiayPhepTamGiuCommand : CreateOrUpdateCommand, IRequest<ApiResult<GiayPhepTamGiuDto>>, IMapFrom<GiayPhepTamGiu>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateGiayPhepTamGiuCommand, GiayPhepTamGiu>()
            .IgnoreAllNonExisting();
    }
}