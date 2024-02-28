using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.CoQuanBanHanhs;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class CoQuanBanHanhRepository : RepositoryBase<CoQuanBanHanh, int, CatalogServiceContext>, ICoQuanBanHanhRepository
{
    private readonly DbSet<CoQuanBanHanh> _coQuanBanHanh;

    public CoQuanBanHanhRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _coQuanBanHanh = context.Set<CoQuanBanHanh>();
    }

    public async Task<IEnumerable<CoQuanBanHanh>> GetCoQuanBanHanhsByTerm(string? term)
    {
        return await FindByCondition(x => string.IsNullOrEmpty(term) || x.TenCoQuan.Contains(term) || x.NhomCoQuan.Contains(term)).OrderBy(x => x.TenCoQuan).ToListAsync();
    }

    public async Task<PageList<CoQuanBanHanh>> GetPagedCoQuanBanHanhAsync(CoQuanBanHanhParameter parameter)
    {
        var result = _coQuanBanHanh.Filter(parameter).OrderBy(x => x.TenCoQuan);

        return await PageList<CoQuanBanHanh>.ToPageList(result, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<CoQuanBanHanh> GetCoQuanBanHanhById(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task CreateCoQuanBanHanh(CoQuanBanHanh request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateCoQuanBanHanh(CoQuanBanHanh request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteCoQuanBanHanh(CoQuanBanHanh entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistCoQuanBanHanh(int id)
    {
        var coQuanBanHanhs = await FindByCondition(x => x.Id.Equals(id)).ToListAsync();
        return coQuanBanHanhs != null && coQuanBanHanhs.Any();
    }
}