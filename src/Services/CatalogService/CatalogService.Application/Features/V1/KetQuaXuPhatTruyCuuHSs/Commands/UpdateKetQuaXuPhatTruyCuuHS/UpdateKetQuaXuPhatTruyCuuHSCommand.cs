using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.KetQuaXuPhatTruyCuuHSs;
using CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Commands.UpdateKetQuaXuPhatTruyCuuHS;

public class UpdateKetQuaXuPhatTruyCuuHSCommand : CreateOrUpdateCommand, IRequest<ApiResult<KetQuaXuPhatTruyCuuHSDto>>, IMapFrom<KetQuaXuPhatTruyCuuHS>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateKetQuaXuPhatTruyCuuHSCommand, KetQuaXuPhatTruyCuuHS>().IgnoreAllNonExisting();
    }
}