using Contracts.Common.Interfaces;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Repositories;

public class HinhThucXuPhatChinhRepository : RepositoryBase<HinhThucXuPhatChinh, int, CatalogServiceContext>, IHinhThucXuPhatChinhRepository
{
    private readonly DbSet<HinhThucXuPhatChinh> _HinhThucXuPhatChinh;
    public HinhThucXuPhatChinhRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _HinhThucXuPhatChinh = context.Set<HinhThucXuPhatChinh>();
    }

    public async Task<IEnumerable<HinhThucXuPhatChinh>> GetAllHinhThucXuPhatChinhs()
    {
        return await FindAll().ToListAsync();
    }
    
    public async Task<IEnumerable<HinhThucXuPhatChinh>> GetHinhThucXuPhatChinhsByTerm(string? term)
    {
        return await FindByCondition(x => x.IsDeleted == false && string.IsNullOrEmpty(term) || x.Ten.Contains(term)).ToListAsync();
    }

    public async Task CreateHinhThucXuPhatChinh(HinhThucXuPhatChinh request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateHinhThucXuPhatChinh(HinhThucXuPhatChinh request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteHinhThucXuPhatChinh(HinhThucXuPhatChinh entity)
    {
        await DeleteAsync(entity);
    }
}