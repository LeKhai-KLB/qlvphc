using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.DieuKhoanXuPhats;
using CatalogService.Application.Features.V1.DieuKhoanXuPhats.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanXuPhats.Commands.CreateDieuKhoanXuPhat;

public class CreateDieuKhoanXuPhatCommand : CreateOrUpdateCommand, IRequest<ApiResult<DieuKhoanXuPhatDto>>, IMapFrom<DieuKhoanXuPhat>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateDieuKhoanXuPhatDto, CreateDieuKhoanXuPhatCommand>();
        profile.CreateMap<CreateDieuKhoanXuPhatCommand, DieuKhoanXuPhat>();
    }
}