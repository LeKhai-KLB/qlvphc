using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.KetQuaXuPhatHanhChinhs;
using CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Commands.CreateKetQuaXuPhatHanhChinh;

public class CreateKetQuaXuPhatHanhChinhCommand : CreateOrUpdateCommand, IRequest<ApiResult<KetQuaXuPhatHanhChinhDto>>, IMapFrom<KetQuaXuPhatHanhChinh>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateKetQuaXuPhatHanhChinhDto, CreateKetQuaXuPhatHanhChinhCommand>();
        profile.CreateMap<CreateKetQuaXuPhatHanhChinhCommand, KetQuaXuPhatHanhChinh>();
    }
}