using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.CoQuanBanHanhs;
using CatalogService.Application.Features.V1.CoQuanBanHanhs.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuanBanHanhs.Commands.CreateCoQuanBanHanh;

public class CreateCoQuanBanHanhCommand : CreateOrUpdateCommand, IRequest<ApiResult<CoQuanBanHanhDto>>, IMapFrom<CoQuanBanHanh>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCoQuanBanHanhDto, CreateCoQuanBanHanhCommand>();
        profile.CreateMap<CreateCoQuanBanHanhCommand, CoQuanBanHanh>();
    }
}