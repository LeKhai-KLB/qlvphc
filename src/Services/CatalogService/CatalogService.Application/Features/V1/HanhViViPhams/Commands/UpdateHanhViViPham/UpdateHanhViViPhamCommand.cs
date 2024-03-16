using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.HanhViViPhams;
using CatalogService.Application.Features.V1.HanhViViPhams.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HanhViViPhams.Commands.UpdateHanhViViPham;

public class UpdateHanhViViPhamCommand : CreateOrUpdateCommand, IRequest<ApiResult<HanhViViPhamDto>>, IMapFrom<HanhViViPham>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateHanhViViPhamCommand, HanhViViPham>().IgnoreAllNonExisting();
    }
}