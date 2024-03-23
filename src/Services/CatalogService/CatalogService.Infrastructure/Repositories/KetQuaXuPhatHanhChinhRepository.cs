using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.KetQuaXuPhatHanhChinhs;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class KetQuaXuPhatHanhChinhRepository : RepositoryBase<KetQuaXuPhatHanhChinh, int, CatalogServiceContext>, IKetQuaXuPhatHanhChinhRepository
{
    private readonly DbSet<KetQuaXuPhatHanhChinh> _KetQuaXuPhatHanhChinh;

    public KetQuaXuPhatHanhChinhRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _KetQuaXuPhatHanhChinh = context.Set<KetQuaXuPhatHanhChinh>();
    }

    public async Task<IEnumerable<KetQuaXuPhatHanhChinh>> GetAllKetQuaXuPhatHanhChinhs()
    {
        return await FindAll().ToListAsync();
    }

    public async Task<PageList<KetQuaXuPhatHanhChinh>> GetPagedKetQuaXuPhatHanhChinhAsync(KetQuaXuPhatHanhChinhParameter parameter)
    {
        var query = _KetQuaXuPhatHanhChinh.Filter(parameter);

        if (!string.IsNullOrEmpty(parameter.OrderBy))
        {
            query = query.OrderBy(parameter.OrderBy);
        }

        if (!string.IsNullOrEmpty(parameter.SearchTerm))
        {
            query = query.Where(x => string.IsNullOrEmpty(parameter.SearchTerm)
                || x.NoiDung.Contains(parameter.SearchTerm)
                || x.ThongBaoChapHanh.Contains(parameter.SearchTerm));
        }

        return await PageList<KetQuaXuPhatHanhChinh>.ToPageList(query, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<KetQuaXuPhatHanhChinh> GetKetQuaXuPhatHanhChinhById(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task CreateKetQuaXuPhatHanhChinh(KetQuaXuPhatHanhChinh request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateKetQuaXuPhatHanhChinh(KetQuaXuPhatHanhChinh request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteKetQuaXuPhatHanhChinh(KetQuaXuPhatHanhChinh entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistKetQuaXuPhatHanhChinh(int id)
    {
        var KetQuaXuPhatHanhChinhs = await FindByCondition(x => x.Id.Equals(id)).ToListAsync();
        return KetQuaXuPhatHanhChinhs != null && KetQuaXuPhatHanhChinhs.Any();
    }
}