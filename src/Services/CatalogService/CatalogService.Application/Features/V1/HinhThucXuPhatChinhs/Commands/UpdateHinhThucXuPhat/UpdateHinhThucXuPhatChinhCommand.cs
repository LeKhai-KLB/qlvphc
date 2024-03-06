using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.HinhThucXuPhatChinhs;
using CatalogService.Application.Features.V1.HinhThucXuPhatChinhs.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatChinhs.Commands.UpdateHinhThucXuPhatChinh;

public class UpdateHinhThucXuPhatChinhCommand : CreateOrUpdateCommand, IRequest<ApiResult<HinhThucXuPhatChinhDto>>, IMapFrom<HinhThucXuPhatChinh>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateHinhThucXuPhatChinhCommand, HinhThucXuPhatChinh>()
            .IgnoreAllNonExisting();
    }
}