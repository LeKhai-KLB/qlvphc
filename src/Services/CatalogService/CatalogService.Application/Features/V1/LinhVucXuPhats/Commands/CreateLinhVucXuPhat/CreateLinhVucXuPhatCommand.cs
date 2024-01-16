using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.LinhVucXuPhats;
using CatalogService.Application.Features.V1.LinhVucXuPhats.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LinhVucXuPhats.Commands.CreateLinhVucXuPhat;

public class CreateLinhVucXuPhatCommand : CreateOrUpdateCommand, IRequest<ApiResult<LinhVucXuPhatDto>>, IMapFrom<LinhVucXuPhat>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateLinhVucXuPhatDto, CreateLinhVucXuPhatCommand>();
        profile.CreateMap<CreateLinhVucXuPhatCommand, LinhVucXuPhat>();
    }
}