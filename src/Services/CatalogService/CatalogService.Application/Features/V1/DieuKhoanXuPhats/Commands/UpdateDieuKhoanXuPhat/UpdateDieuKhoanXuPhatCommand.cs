using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.DieuKhoanXuPhats;
using CatalogService.Application.Features.V1.DieuKhoanXuPhats.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanXuPhats.Commands.UpdateDieuKhoanXuPhat;

public class UpdateDieuKhoanXuPhatCommand : CreateOrUpdateCommand, IRequest<ApiResult<DieuKhoanXuPhatDto>>, IMapFrom<DieuKhoanXuPhat>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateDieuKhoanXuPhatCommand, DieuKhoanXuPhat>().IgnoreAllNonExisting();
    }
}