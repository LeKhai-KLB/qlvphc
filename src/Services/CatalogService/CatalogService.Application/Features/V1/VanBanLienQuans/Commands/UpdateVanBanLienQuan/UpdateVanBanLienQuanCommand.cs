using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.VanBanLienQuans;
using CatalogService.Application.Features.V1.VanBanLienQuans.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanLienQuans.Commands.UpdateVanBanLienQuan;

public class UpdateVanBanLienQuanCommand : CreateOrUpdateCommand, IRequest<ApiResult<VanBanLienQuanDto>>, IMapFrom<VanBanLienQuan>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateVanBanLienQuanCommand, VanBanLienQuan>().IgnoreAllNonExisting();
    }
}