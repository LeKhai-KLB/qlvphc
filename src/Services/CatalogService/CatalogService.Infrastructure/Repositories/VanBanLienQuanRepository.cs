using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.VanBanLienQuans;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class VanBanLienQuanRepository : RepositoryBase<VanBanLienQuan, int, CatalogServiceContext>, IVanBanLienQuanRepository
{
    private readonly DbSet<VanBanLienQuan> _vanBanLienQuan;

    public VanBanLienQuanRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _vanBanLienQuan = context.Set<VanBanLienQuan>();
    }

    public async Task<PageList<VanBanLienQuan>> GetPagedByVanBanPhapLuatId(VanBanLienQuanParameter parameter)
    {
        var result = _vanBanLienQuan.Filter(parameter).OrderBy(x => x.Ten);

        return await PageList<VanBanLienQuan>.ToPageList(result, parameter.PageNumber, parameter.PageSize);
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