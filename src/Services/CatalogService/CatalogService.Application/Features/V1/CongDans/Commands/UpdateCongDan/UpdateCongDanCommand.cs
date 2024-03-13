using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.CongDans;
using CatalogService.Application.Features.V1.CongDans.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;
using Infrastructure.Mappings;

namespace CatalogService.Application.Features.V1.CongDans.Commands.UpdateCongDan;

public class UpdateCongDanCommand : CreateOrUpdateCommand, IRequest<ApiResult<CongDanDto>>, IMapFrom<CongDan>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateCongDanCommand, CongDan>().IgnoreAllNonExisting();
    }
}