using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.CongDans;
using CatalogService.Application.Features.V1.CongDans.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CongDans.Commands.CreateCongDan;

public class CreateCongDanCommand : CreateOrUpdateCommand, IRequest<ApiResult<CongDanDto>>, IMapFrom<CongDan>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCongDanDto, CreateCongDanCommand>();
        profile.CreateMap<CreateCongDanCommand, CongDan>();
    }
}