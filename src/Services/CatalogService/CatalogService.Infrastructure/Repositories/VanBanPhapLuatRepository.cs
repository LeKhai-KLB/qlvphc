
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Repositories;

public class VanBanPhapLuatRepository : RepositoryBase<VanBanPhapLuat, int, CatalogServiceContext>, IVanBanPhapLuatRepository
{
    public VanBanPhapLuatRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {

    }

    public async Task<IEnumerable<VanBanPhapLuat>> GetAllVanBanPhapLuat()
    {
        return await FindAll().ToListAsync();
    }

    public async Task<VanBanPhapLuat> GetVanBanPhapLuatById(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task CreateVanBanPhapLuat(VanBanPhapLuat request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateVanBanPhapLuat(VanBanPhapLuat request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteVanBanPhapLuat(VanBanPhapLuat entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistVanBanPhapLuat(string soHieu)
    {
        var vanBanPhapLuats = await FindByCondition(x => x.SoHieu.Equals(soHieu)).ToListAsync();
        return vanBanPhapLuats != null && vanBanPhapLuats.Any();
    }
}