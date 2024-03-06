using Contracts.Common.Interfaces;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Repositories;

public class HinhThucXuPhatBoSungRepository : RepositoryBase<HinhThucXuPhatBoSung, int, CatalogServiceContext>, IHinhThucXuPhatBoSungRepository
{
    private readonly DbSet<HinhThucXuPhatBoSung> _HinhThucXuPhatBoSung;
    public HinhThucXuPhatBoSungRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _HinhThucXuPhatBoSung = context.Set<HinhThucXuPhatBoSung>();
    }

    public async Task<IEnumerable<HinhThucXuPhatBoSung>> GetAllHinhThucXuPhatBoSungs()
    {
        return await FindAll().ToListAsync();
    }
    
    public async Task<IEnumerable<HinhThucXuPhatBoSung>> GetHinhThucXuPhatBoSungsByTerm(string? term)
    {
        return await FindByCondition(x => x.IsDeleted == false && string.IsNullOrEmpty(term) || x.Ten.Contains(term)).ToListAsync();
    }

    public async Task CreateHinhThucXuPhatBoSung(HinhThucXuPhatBoSung request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateHinhThucXuPhatBoSung(HinhThucXuPhatBoSung request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteHinhThucXuPhatBoSung(HinhThucXuPhatBoSung entity)
    {
        await DeleteAsync(entity);
    }
}