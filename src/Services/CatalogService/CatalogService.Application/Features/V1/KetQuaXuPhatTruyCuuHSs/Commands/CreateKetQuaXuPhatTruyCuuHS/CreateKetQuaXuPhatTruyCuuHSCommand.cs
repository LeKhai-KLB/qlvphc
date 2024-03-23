using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.KetQuaXuPhatTruyCuuHSs;
using CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Commands.CreateKetQuaXuPhatTruyCuuHS;

public class CreateKetQuaXuPhatTruyCuuHSCommand : CreateOrUpdateCommand, IRequest<ApiResult<KetQuaXuPhatTruyCuuHSDto>>, IMapFrom<KetQuaXuPhatTruyCuuHS>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateKetQuaXuPhatTruyCuuHSDto, CreateKetQuaXuPhatTruyCuuHSCommand>();
        profile.CreateMap<CreateKetQuaXuPhatTruyCuuHSCommand, KetQuaXuPhatTruyCuuHS>();
    }
}