using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Common.Models.ChiTietHSXLVPVVBGQs;
using CatalogService.Application.Features.V1.ChiTietHSXLVPVVBGQs.Common;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ChiTietHSXLVPVVBGQs.Commands.CreateChiTietHSXLVPVVBGQ;

public class CreateChiTietHSXLVPVVBGQCommand : CreateOrUpdateCommand, IRequest<ApiResult<ChiTietHSXLVPVVBGQDto>>, IMapFrom<ChiTietHSXLVPVVBGQ>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateChiTietHSXLVPVVBGQDto, CreateChiTietHSXLVPVVBGQCommand>();
        profile.CreateMap<CreateChiTietHSXLVPVVBGQCommand, ChiTietHSXLVPVVBGQ>();
    }
}