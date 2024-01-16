using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.LinhVucXuPhats;
using CatalogService.Application.Features.V1.LinhVucXuPhats.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LinhVucXuPhats.Commands.UpdateLinhVucXuPhat;

public class UpdateLinhVucXuPhatCommand : CreateOrUpdateCommand, IRequest<ApiResult<LinhVucXuPhatDto>>, IMapFrom<LinhVucXuPhat>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateLinhVucXuPhatCommand, LinhVucXuPhat>().IgnoreAllNonExisting();
    }
}