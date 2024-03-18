using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.ChiTietHSXLVPVVBGQs;
using CatalogService.Application.Features.V1.ChiTietHSXLVPVVBGQs.Common;
using CatalogService.Domain.Entities;
using Infrastructure.Mappings;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ChiTietHSXLVPVVBGQs.Commands.UpdateChiTietHSXLVPVVBGQ;

public class UpdateChiTietHSXLVPVVBGQCommand : CreateOrUpdateCommand, IRequest<ApiResult<ChiTietHSXLVPVVBGQDto>>, IMapFrom<ChiTietHSXLVPVVBGQ>
{
    public int Id { get; private set; }

    public void SetId(int id)
    {
        Id = id;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateChiTietHSXLVPVVBGQCommand, ChiTietHSXLVPVVBGQ>().IgnoreAllNonExisting();
    }
}