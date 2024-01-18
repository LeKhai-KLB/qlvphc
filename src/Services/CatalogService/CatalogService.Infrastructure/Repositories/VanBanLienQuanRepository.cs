using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Repositories;

public class VanBanLienQuanRepository : RepositoryBase<VanBanLienQuan, int, CatalogServiceContext>, IVanBanLienQuanRepository
{
    public VanBanLienQuanRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {

    }

    public async Task<IEnumerable<VanBanLienQuan>> GetVanBanLienQuanByVanBanPhapLuatId(int id)
    {
        var result = FindByCondition(x => x.VanBanPhapLuatId.Equals(id)).OrderBy(x => x.Ten);

        return result;
    }

    public async Task<VanBanLienQuan> GetVanBanLienQuanById(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task CreateVanBanLienQuan(VanBanLienQuan request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateVanBanLienQuan(VanBanLienQuan request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteVanBanLienQuan(VanBanLienQuan entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistVanBanLienQuan(string ten)
    {
        var vanBanLienQuans = await FindByCondition(x => x.Ten.Equals(ten)).ToListAsync();
        return vanBanLienQuans != null && vanBanLienQuans.Any();
    }
}