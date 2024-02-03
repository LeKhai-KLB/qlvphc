using Contracts.Common.Interfaces;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.DanhMucDinhDanhs;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class DanhMucDinhDanhRepository : RepositoryBase<DanhMucDinhDanh, int, CatalogServiceContext>, IDanhMucDinhDanhRepository
{
    private readonly DbSet<DanhMucDinhDanh> _DanhMucDinhDanh;
    public DanhMucDinhDanhRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _DanhMucDinhDanh = context.Set<DanhMucDinhDanh>();
    }

    public async Task<PageList<DanhMucDinhDanh>> GetPagedDanhMucDinhDanhAsync(DanhMucDinhDanhParameter parameter)
    {
        var query = _DanhMucDinhDanh.Filter(parameter)
            .OrderBy(parameter.OrderBy);
        
        if (!string.IsNullOrEmpty(parameter.SearchTerm))
        {
            query = query.Where(x => x.MaDinhDanh.Contains(parameter.SearchTerm) || x.Ten.Contains(parameter.SearchTerm) || x.MaDinhDanhTCVN.Contains(parameter.SearchTerm));
        }

        return await PageList<DanhMucDinhDanh>.ToPageList(query, parameter.PageNumber, parameter.PageSize);
    }
    
    public async Task<IEnumerable<DanhMucDinhDanh>> GetDanhMucDinhDanhsByTerm(string? term)
    {
        return await FindByCondition(x => x.IsDeleted == false && string.IsNullOrEmpty(term) || x.Ten.Contains(term)).ToListAsync();
    }

    public async Task CreateDanhMucDinhDanh(DanhMucDinhDanh request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateDanhMucDinhDanh(DanhMucDinhDanh request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteDanhMucDinhDanh(DanhMucDinhDanh entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistMaDinhDanhDanhMucDinhDanh(string maDinhDanh)
    {
        var danhMucDinhDanh = await FindByCondition(x => x.MaDinhDanh.Equals(maDinhDanh)).ToListAsync();
        return danhMucDinhDanh != null && danhMucDinhDanh.Any();
    }
}