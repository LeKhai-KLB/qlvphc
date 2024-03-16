using CatalogService.Application.Common.Models.DieuKhoanXuPhats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanXuPhats.Queries.GetAllDieuKhoanXuPhats;

public class GetAllDieuKhoanXuPhatsQuery : IRequest<ApiResult<IEnumerable<DieuKhoanXuPhatDto>>>
{
    public GetAllDieuKhoanXuPhatsQuery()
    {
    }
}