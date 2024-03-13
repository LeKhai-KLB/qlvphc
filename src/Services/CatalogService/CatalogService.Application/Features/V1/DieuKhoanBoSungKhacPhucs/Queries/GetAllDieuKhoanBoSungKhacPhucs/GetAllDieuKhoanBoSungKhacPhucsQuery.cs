using CatalogService.Application.Common.Models.DieuKhoanBoSungKhacPhucs;
using CatalogService.Application.Parameters.DieuKhoanBoSungKhacPhucs;
using CatalogService.Domain.Constants;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Queries.GetAllDieuKhoanBoSungKhacPhucs;

public class GetAllDieuKhoanBoSungKhacPhucsQuery : IRequest<ApiResult<IEnumerable<DieuKhoanBoSungKhacPhucDto>>>
{
    public int DieuKhoanXuPhatId { get; set; }

    public LoaiDieuKhoan LoaiDieuKhoan { get; set; }

    public GetAllDieuKhoanBoSungKhacPhucsQuery(DieuKhoanBoSungKhacPhucDropDownParameter request)
    {
        DieuKhoanXuPhatId = request.DieuKhoanXuPhatId;
        LoaiDieuKhoan = request.LoaiDieuKhoan;
    }
}