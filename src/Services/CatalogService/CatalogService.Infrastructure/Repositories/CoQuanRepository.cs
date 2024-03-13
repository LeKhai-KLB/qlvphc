using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.CoQuans;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class CoQuanRepository : RepositoryBase<CoQuan, int, CatalogServiceContext>, ICoQuanRepository
{
    private readonly DbSet<CoQuan> _coQuan;

    public CoQuanRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _coQuan = context.Set<CoQuan>();
    }

    public async Task<IEnumerable<CoQuan>> GetAllCoQuans()
    {
        return await FindAll().ToListAsync();
    }

    public async Task<PageList<CoQuan>> GetPagedCoQuanAsync(CoQuanParameter parameter)
    {
        var query = _coQuan.Filter(parameter);

        if (!string.IsNullOrEmpty(parameter.OrderBy))
        {
            query = query.OrderBy(parameter.OrderBy);
        }

        if (!string.IsNullOrEmpty(parameter.SearchTerm))
        {
            query = query.Where(x => string.IsNullOrEmpty(parameter.SearchTerm)
                || x.TenCoQuan.Contains(parameter.SearchTerm)
                || x.DiaChi.Contains(parameter.SearchTerm)
                || x.DienThoai.Contains(parameter.SearchTerm)
                || x.Email.Contains(parameter.SearchTerm)
                || x.Website.Contains(parameter.SearchTerm)
                || x.SoFax.Contains(parameter.SearchTerm));
        }

        return await PageList<CoQuan>.ToPageList(query, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<CoQuan> GetCoQuanById(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task CreateCoQuan(CoQuan request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateCoQuan(CoQuan request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteCoQuan(CoQuan entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistCoQuan(int id)
    {
        var coQuans = await FindByCondition(x => x.Id.Equals(id)).ToListAsync();
        return coQuans != null && coQuans.Any();
    }
}