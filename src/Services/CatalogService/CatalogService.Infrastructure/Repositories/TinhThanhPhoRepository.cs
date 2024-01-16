using Contracts.Common.Interfaces;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.TinhThanhPhos;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class TinhThanhPhoRepository : RepositoryBase<TinhThanhPho, int, CatalogServiceContext>, ITinhThanhPhoRepository
{
    private readonly DbSet<TinhThanhPho> _tinhthanhpho;
    public TinhThanhPhoRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _tinhthanhpho = context.Set<TinhThanhPho>();
    }

    public async Task<PageList<TinhThanhPho>> GetPagedTinhThanhPhoAsync(TinhThanhPhoParameter parameter)
    {
        var result = _tinhthanhpho.Filter(parameter)
            .OrderBy(x => x.Ten);

        return await PageList<TinhThanhPho>.ToPageList(result, parameter.PageNumber, parameter.PageSize);
    }
    
    public async Task<IEnumerable<TinhThanhPho>> GetTinhThanhPhosByTerm(string? term)
    {
        return await FindByCondition(x => x.IsDeleted == false && string.IsNullOrEmpty(term) || x.Ten.Contains(term)).ToListAsync();
    }

    public async Task CreateTinhThanhPho(TinhThanhPho request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateTinhThanhPho(TinhThanhPho request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteTinhThanhPho(TinhThanhPho entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistMaDinhDanhTinhThanhPho(string maDinhDanh)
    {
        var tinhThanhPho = await FindByCondition(x => x.MaDinhDanh.Equals(maDinhDanh)).ToListAsync();
        return tinhThanhPho != null && tinhThanhPho.Any();
    }
}