using CatalogService.Application.Common.Models.HanhViViPhams;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HanhViViPhams.Queries.GetHanhViViPhamById;

public class GetHanhViViPhamByIdQuery : IRequest<ApiResult<HanhViViPhamDto>>
{
    public int Id { get; set; }

    public GetHanhViViPhamByIdQuery(int id)
    {
        Id = id;
    }
}