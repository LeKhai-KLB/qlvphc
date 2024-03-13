using CatalogService.Application.Common.Models.DieuKhoanBoSungKhacPhucs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Queries.GetDieuKhoanBoSungKhacPhucById;

public class GetDieuKhoanBoSungKhacPhucByIdQuery : IRequest<ApiResult<DieuKhoanBoSungKhacPhucDto>>
{
    public int Id { get; set; }

    public GetDieuKhoanBoSungKhacPhucByIdQuery(int id)
    {
        Id = id;
    }
}