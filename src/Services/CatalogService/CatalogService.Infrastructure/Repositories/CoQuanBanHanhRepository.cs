using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Repositories;

public class CoQuanBanHanhRepository : RepositoryBase<CoQuanBanHanh, int, CatalogServiceContext>, ICoQuanBanHanhRepository
{
    public CoQuanBanHanhRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {

    }

    public async Task<IEnumerable<CoQuanBanHanh>> GetAllCoQuanBanHanh()
    {
        return await FindAll().ToListAsync();
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

    public async Task<bool> CheckExistCoQuanBanHanh(string ten)
    {
        var coQuanBanHanhs = await FindByCondition(x => x.TenCoQuan.Equals(ten)).ToListAsync();
        return coQuanBanHanhs != null && coQuanBanHanhs.Any();
    }
}