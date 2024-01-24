using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.VanBanGiaiQuyets;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class VanBanGiaiQuyetRepository : RepositoryBase<VanBanGiaiQuyet, int, CatalogServiceContext>, IVanBanGiaiQuyetRepository
{
    private readonly DbSet<VanBanGiaiQuyet> _vanBanGiaiQuyet;

    public VanBanGiaiQuyetRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _vanBanGiaiQuyet = context.Set<VanBanGiaiQuyet>();
    }

    public async Task<PageList<VanBanGiaiQuyet>> GetPagedVanBanGiaiQuyetAsync(VanBanGiaiQuyetParameter parameter)
    {
        var result = _vanBanGiaiQuyet.Filter(parameter).OrderBy(x => x.TenGiayTo);

        return await PageList<VanBanGiaiQuyet>.ToPageList(result, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<IEnumerable<VanBanGiaiQuyet>> GetAllVanBanGiaiQuyet()
    {
        return await FindAll().ToListAsync();
    }

    public async Task<VanBanGiaiQuyet> GetVanBanGiaiQuyetById(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task CreateVanBanGiaiQuyet(VanBanGiaiQuyet request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateVanBanGiaiQuyet(VanBanGiaiQuyet request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteVanBanGiaiQuyet(VanBanGiaiQuyet entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistVanBanGiaiQuyet(string maGiayTo)
    {
        var vanBanGiaiQuyets = await FindByCondition(x => x.MaGiayTo.Equals(maGiayTo)).ToListAsync();
        return vanBanGiaiQuyets != null && vanBanGiaiQuyets.Any();
    }
}