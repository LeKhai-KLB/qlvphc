using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.ThamQuyenXuPhats;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class ThamQuyenXuPhatRepository : RepositoryBase<ThamQuyenXuPhat, int, CatalogServiceContext>, IThamQuyenXuPhatRepository
{
    private readonly DbSet<ThamQuyenXuPhat> _thamQuyenXuPhat;

    public ThamQuyenXuPhatRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _thamQuyenXuPhat = context.Set<ThamQuyenXuPhat>();
    }

    public async Task<PageList<ThamQuyenXuPhat>> GetPagedThamQuyenXuPhatAsync(ThamQuyenXuPhatParameter parameter)
    {
        var query = _thamQuyenXuPhat.Filter(parameter);

        if (!string.IsNullOrEmpty(parameter.OrderBy))
        {
            query = query.OrderBy(parameter.OrderBy);
        }

        if (!string.IsNullOrEmpty(parameter.SearchTerm))
        {
            query = query.Where(x => x.IsDeleted == false
                && (string.IsNullOrEmpty(parameter.SearchTerm)
                || x.ThamQuyen.Contains(parameter.SearchTerm)));
        }

        return await PageList<ThamQuyenXuPhat>.ToPageList(query, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<ThamQuyenXuPhat> GetThamQuyenXuPhatById(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task CreateThamQuyenXuPhat(ThamQuyenXuPhat request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateThamQuyenXuPhat(ThamQuyenXuPhat request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteThamQuyenXuPhat(ThamQuyenXuPhat entity)
    {
        await DeleteAsync(entity);
    }
}