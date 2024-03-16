using CatalogService.Application.Common.Models.HanhViViPhams;
using CatalogService.Application.Parameters.HanhViViPhams;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HanhViViPhams.Queries.GetPagedHanhViViPham;

public class GetPagedHanhViViPhamQuery : IRequest<PagedResponse<IEnumerable<HanhViViPhamDto>>>
{
    public string? SearchTerm { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }

    public string? OrderBy { get; set; }

    public int? QuyetDinhXuPhatId { get; set; }

    public int? HoSoXuLyViPhamId { get; set; }

    public GetPagedHanhViViPhamQuery(HanhViViPhamParameter request)
    {
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        SearchTerm = request.SearchTerm;
        QuyetDinhXuPhatId = request.QuyetDinhXuPhatId;
        HoSoXuLyViPhamId = request.HoSoXuLyViPhamId;
    }
}