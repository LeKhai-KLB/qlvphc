using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.CoQuans;
using CatalogService.Application.Features.V1.CoQuans.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuans.Commands.CreateCoQuan;

public class CreateCoQuanCommand : CreateOrUpdateCommand, IRequest<ApiResult<CoQuanDto>>, IMapFrom<CoQuan>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCoQuanDto, CreateCoQuanCommand>();
        profile.CreateMap<CreateCoQuanCommand, CoQuan>();
    }
}