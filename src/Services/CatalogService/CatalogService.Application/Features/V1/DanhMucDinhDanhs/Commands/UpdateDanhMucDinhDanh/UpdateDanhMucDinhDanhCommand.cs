using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.DanhMucDinhDanhs;
using CatalogService.Application.Features.V1.DanhMucDinhDanhs.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DanhMucDinhDanhs.Commands.UpdateDanhMucDinhDanh;

public class UpdateDanhMucDinhDanhCommand : CreateOrUpdateCommand, IRequest<ApiResult<DanhMucDinhDanhDto>>, IMapFrom<DanhMucDinhDanh>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateDanhMucDinhDanhCommand, DanhMucDinhDanh>()
            .IgnoreAllNonExisting();
    }
}