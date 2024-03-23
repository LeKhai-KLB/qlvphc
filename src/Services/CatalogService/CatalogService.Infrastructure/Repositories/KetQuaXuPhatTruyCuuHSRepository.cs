using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.KetQuaXuPhatTruyCuuHSs;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class KetQuaXuPhatTruyCuuHSRepository : RepositoryBase<KetQuaXuPhatTruyCuuHS, int, CatalogServiceContext>, IKetQuaXuPhatTruyCuuHSRepository
{
    private readonly DbSet<KetQuaXuPhatTruyCuuHS> _KetQuaXuPhatTruyCuuHS;

    public KetQuaXuPhatTruyCuuHSRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _KetQuaXuPhatTruyCuuHS = context.Set<KetQuaXuPhatTruyCuuHS>();
    }

    public async Task<IEnumerable<KetQuaXuPhatTruyCuuHS>> GetAllKetQuaXuPhatTruyCuuHSs()
    {
        return await FindAll().ToListAsync();
    }

    public async Task<PageList<KetQuaXuPhatTruyCuuHS>> GetPagedKetQuaXuPhatTruyCuuHSAsync(KetQuaXuPhatTruyCuuHSParameter parameter)
    {
        var query = _KetQuaXuPhatTruyCuuHS.Filter(parameter);

        if (!string.IsNullOrEmpty(parameter.OrderBy))
        {
            query = query.OrderBy(parameter.OrderBy);
        }

        if (!string.IsNullOrEmpty(parameter.SearchTerm))
        {
            query = query.Where(x => string.IsNullOrEmpty(parameter.SearchTerm)
                || x.NoiDung.Contains(parameter.SearchTerm));
        }

        return await PageList<KetQuaXuPhatTruyCuuHS>.ToPageList(query, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<KetQuaXuPhatTruyCuuHS> GetKetQuaXuPhatTruyCuuHSById(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task CreateKetQuaXuPhatTruyCuuHS(KetQuaXuPhatTruyCuuHS request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateKetQuaXuPhatTruyCuuHS(KetQuaXuPhatTruyCuuHS request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteKetQuaXuPhatTruyCuuHS(KetQuaXuPhatTruyCuuHS entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistKetQuaXuPhatTruyCuuHS(int id)
    {
        var KetQuaXuPhatTruyCuuHSs = await FindByCondition(x => x.Id.Equals(id)).ToListAsync();
        return KetQuaXuPhatTruyCuuHSs != null && KetQuaXuPhatTruyCuuHSs.Any();
    }
}