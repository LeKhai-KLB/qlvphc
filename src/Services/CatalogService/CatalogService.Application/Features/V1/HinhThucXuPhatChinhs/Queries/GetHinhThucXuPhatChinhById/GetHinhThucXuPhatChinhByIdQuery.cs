using CatalogService.Application.Common.Models.HinhThucXuPhatChinhs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatChinhs.Queries.GetHinhThucXuPhatChinhById;
public class GetHinhThucXuPhatChinhByIdQuery : IRequest<ApiResult<HinhThucXuPhatChinhDto>>
{
    public int Id { get; set; }

    public GetHinhThucXuPhatChinhByIdQuery(int id)
    {
        Id = id;
    }
}
