using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.HanhViViPhams;
using CatalogService.Application.Features.V1.HanhViViPhams.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HanhViViPhams.Commands.CreateHanhViViPham;

public class CreateHanhViViPhamCommand : CreateOrUpdateCommand, IRequest<ApiResult<HanhViViPhamDto>>, IMapFrom<HanhViViPham>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateHanhViViPhamDto, CreateHanhViViPhamCommand>();
        profile.CreateMap<CreateHanhViViPhamCommand, HanhViViPham>();
    }
}