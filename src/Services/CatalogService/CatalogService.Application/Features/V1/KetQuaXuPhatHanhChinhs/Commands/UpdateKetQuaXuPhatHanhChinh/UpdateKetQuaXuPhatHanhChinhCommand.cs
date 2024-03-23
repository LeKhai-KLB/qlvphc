using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.KetQuaXuPhatHanhChinhs;
using CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Commands.UpdateKetQuaXuPhatHanhChinh;

public class UpdateKetQuaXuPhatHanhChinhCommand : CreateOrUpdateCommand, IRequest<ApiResult<KetQuaXuPhatHanhChinhDto>>, IMapFrom<KetQuaXuPhatHanhChinh>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateKetQuaXuPhatHanhChinhCommand, KetQuaXuPhatHanhChinh>().IgnoreAllNonExisting();
    }
}