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

    public async Task<IEnumerable<LoaiVanBan>> GetAllLoaiVanBan()
    {
        return await FindAll().ToListAsync();
    }

    public async Task<PageList<LoaiVanBan>> GetPagedLoaiVanBanAsync(LoaiVanBanParameter parameter)
    {
        var result = _loaiVanBan.Filter(parameter).OrderBy(x => x.Ten);

        return await PageList<LoaiVanBan>.ToPageList(result, parameter.PageNumber, parameter.PageSize);
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