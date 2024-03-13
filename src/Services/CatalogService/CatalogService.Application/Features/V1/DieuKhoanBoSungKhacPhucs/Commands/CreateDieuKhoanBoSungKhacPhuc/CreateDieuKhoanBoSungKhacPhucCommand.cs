using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.DieuKhoanBoSungKhacPhucs;
using CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Commands.CreateDieuKhoanBoSungKhacPhuc;

public class CreateDieuKhoanBoSungKhacPhucCommand : CreateOrUpdateCommand, IRequest<ApiResult<DieuKhoanBoSungKhacPhucDto>>, IMapFrom<DieuKhoanBoSungKhacPhuc>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateDieuKhoanBoSungKhacPhucDto, CreateDieuKhoanBoSungKhacPhucCommand>();
        profile.CreateMap<CreateDieuKhoanBoSungKhacPhucCommand, DieuKhoanBoSungKhacPhuc>();
    }
}