using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.TinhThanhPhos;
using CatalogService.Application.Features.V1.TinhThanhPhos.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.TinhThanhPhos.Commands.UpdateTinhThanhPho;

public class UpdateTinhThanhPhoCommand : CreateOrUpdateCommand, IRequest<ApiResult<TinhThanhPhoDto>>, IMapFrom<TinhThanhPho>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateTinhThanhPhoCommand, TinhThanhPho>()
            .IgnoreAllNonExisting();
    }
}