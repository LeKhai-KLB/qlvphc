using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Repositories;

public class LoaiVanBanRepository : RepositoryBase<LoaiVanBan, int, CatalogServiceContext>, ILoaiVanBanRepository
{
    public LoaiVanBanRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {

    }

    public async Task<IEnumerable<LoaiVanBan>> GetAllLoaiVanBan()
    {
        return await FindAll().ToListAsync();
    }

    public async Task<LoaiVanBan> GetLoaiVanBanById(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task CreateLoaiVanBan(LoaiVanBan request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateLoaiVanBan(LoaiVanBan request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteLoaiVanBan(LoaiVanBan entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistLoaiVanBan(string ten)
    {
        var loaiVanBans = await FindByCondition(x => x.Ten.Equals(ten)).ToListAsync();
        return loaiVanBans != null && loaiVanBans.Any();
    }
}