using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.QuanHuyens;
using CatalogService.Application.Features.V1.QuanHuyens.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.QuanHuyens.Commands.UpdateQuanHuyen;

public class UpdateQuanHuyenCommand : CreateOrUpdateCommand, IRequest<ApiResult<QuanHuyenDto>>, IMapFrom<QuanHuyen>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateQuanHuyenCommand, QuanHuyen>()
            .IgnoreAllNonExisting();
    }
}