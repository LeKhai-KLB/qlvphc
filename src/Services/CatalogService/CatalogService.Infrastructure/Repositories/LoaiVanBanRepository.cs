using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.LoaiVanBans;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class LoaiVanBanRepository : RepositoryBase<LoaiVanBan, int, CatalogServiceContext>, ILoaiVanBanRepository
{
    private readonly DbSet<LoaiVanBan> _loaiVanBan;

    public LoaiVanBanRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _loaiVanBan = context.Set<LoaiVanBan>();
    }

    public async Task<IEnumerable<LoaiVanBan>> GetAllLoaiVanBans()
    {
        return await FindAll().ToListAsync();
    }

    public async Task<PageList<LoaiVanBan>> GetPagedLoaiVanBanAsync(LoaiVanBanParameter parameter)
    {
        var query = _loaiVanBan.Filter(parameter);

        if (!string.IsNullOrEmpty(parameter.OrderBy))
        {
            query = query.OrderBy(parameter.OrderBy);
        }

        if (!string.IsNullOrEmpty(parameter.SearchTerm))
        {
            query = query.Where(x => string.IsNullOrEmpty(parameter.SearchTerm)
                || x.Ten.Contains(parameter.SearchTerm));
        }

        return await PageList<LoaiVanBan>.ToPageList(query, parameter.PageNumber, parameter.PageSize);
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

    public async Task<bool> CheckExistLoaiVanBan(int id)
    {
        var loaiVanBans = await FindByCondition(x => x.Id.Equals(id)).ToListAsync();
        return loaiVanBans != null && loaiVanBans.Any();
    }
}