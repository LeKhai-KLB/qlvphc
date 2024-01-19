using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.VanBanLienQuans;
using CatalogService.Application.Features.V1.VanBanLienQuans.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanLienQuans.Commands.CreateVanBanLienQuan;

public class CreateVanBanLienQuanCommand : CreateOrUpdateCommand, IRequest<ApiResult<VanBanLienQuanDto>>, IMapFrom<VanBanLienQuan>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateVanBanLienQuanDto, CreateVanBanLienQuanCommand>();
        profile.CreateMap<CreateVanBanLienQuanCommand, VanBanLienQuan>();
    }
}