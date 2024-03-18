using CatalogService.Application.Common.Models.ChiTietHSXLVPVVBGQs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ChiTietHSXLVPVVBGQs.Queries.GetChiTietHSXLVPVVBGQById;

public class GetChiTietHSXLVPVVBGQByIdQuery : IRequest<ApiResult<ChiTietHSXLVPVVBGQDto>>
{
    public int Id { get; set; }

    public GetChiTietHSXLVPVVBGQByIdQuery(int id)
    {
        Id = id;
    }
}