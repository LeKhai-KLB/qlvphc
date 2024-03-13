using AutoMapper;
using CatalogService.Application.Common.Mappings;
using CatalogService.Application.Features.V1.CoQuans.Queries.GetPagedCoQuan;
using CatalogService.Application.Parameters.CoQuans;
using CatalogService.Domain.Entities;
using Shared.Common.Constants;

namespace CatalogService.Application.Features.V1.CoQuans.Common;

public class CreateOrUpdateCommand : IMapFrom<CoQuan>
{
    public string? TenCoQuan { get; set; }

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public string? SoFax { get; set; }

    public CapCoQuan? CapCoQuan { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrUpdateCommand, CoQuan>();
        profile.CreateMap<GetPagedCoQuanQuery, CoQuanParameter>();
    }
}