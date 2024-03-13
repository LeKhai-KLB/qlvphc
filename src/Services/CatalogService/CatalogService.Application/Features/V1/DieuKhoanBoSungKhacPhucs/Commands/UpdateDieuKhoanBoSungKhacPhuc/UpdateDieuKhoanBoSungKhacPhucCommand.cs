using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.DieuKhoanBoSungKhacPhucs;
using CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Commands.UpdateDieuKhoanBoSungKhacPhuc;

public class UpdateDieuKhoanBoSungKhacPhucCommand : CreateOrUpdateCommand, IRequest<ApiResult<DieuKhoanBoSungKhacPhucDto>>, IMapFrom<DieuKhoanBoSungKhacPhuc>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateDieuKhoanBoSungKhacPhucCommand, DieuKhoanBoSungKhacPhuc>().IgnoreAllNonExisting();
    }
}