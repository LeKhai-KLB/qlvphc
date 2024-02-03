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
        var query = _vanBanGiaiQuyet.Filter(parameter)
            .OrderBy(parameter.OrderBy);

        if (!string.IsNullOrEmpty(parameter.SearchTerm))
        {
            query = query.Where(x => x.MaGiayTo.Contains(parameter.SearchTerm) || x.TheoNghiDinh.Contains(parameter.SearchTerm) || x.TenGiayTo.Contains(parameter.SearchTerm));
        }

        return await PageList<VanBanGiaiQuyet>.ToPageList(query, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<IEnumerable<VanBanGiaiQuyet>> GetVanBanGiaiQuyetByTerm(string? term)
    {
        return await FindByCondition(x => string.IsNullOrEmpty(term) || x.MaGiayTo.Contains(term) || x.TenGiayTo.Contains(term) || x.TheoNghiDinh.Contains(term)).ToListAsync();
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