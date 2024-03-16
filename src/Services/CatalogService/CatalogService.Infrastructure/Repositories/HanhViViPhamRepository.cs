using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.HanhViViPhams;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class HanhViViPhamRepository : RepositoryBase<HanhViViPham, int, CatalogServiceContext>, IHanhViViPhamRepository
{
    private readonly DbSet<HanhViViPham> _HanhViViPham;

    public HanhViViPhamRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _HanhViViPham = context.Set<HanhViViPham>();
    }

    public async Task<PageList<HanhViViPham>> GetPagedHanhViViPham(HanhViViPhamParameter parameter)
    {
        var query = _HanhViViPham.Filter(parameter);

        if (!string.IsNullOrEmpty(parameter.OrderBy))
        {
            query = query.OrderBy(parameter.OrderBy);
        }

        if (!string.IsNullOrEmpty(parameter.SearchTerm))
        {
            query = query.Where(x => string.IsNullOrEmpty(parameter.SearchTerm)
                || x.QuyDinh.Contains(parameter.SearchTerm)
                || x.GhiChu.Contains(parameter.SearchTerm));
        }

        return await PageList<HanhViViPham>.ToPageList(query, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<HanhViViPham> GetHanhViViPhamById(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task CreateHanhViViPham(HanhViViPham request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateHanhViViPham(HanhViViPham request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteHanhViViPham(HanhViViPham entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistHanhViViPham(int id)
    {
        var chitiet = await FindByCondition(x => x.Id.Equals(id)).ToListAsync();
        return chitiet != null && chitiet.Any();
    }
}