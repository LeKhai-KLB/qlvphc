using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.HoSoXuLyViPhams;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class HoSoXuLyViPhamRepository : RepositoryBase<HoSoXuLyViPham, int, CatalogServiceContext>, IHoSoXuLyViPhamRepository
{
    private readonly DbSet<HoSoXuLyViPham> _hoSoXuLyViPham;
    private readonly DbSet<HSXLVP_VanBanGiaiQuyet> _hSXLVP_VanBanGiaiQuyet;

    public HoSoXuLyViPhamRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _hoSoXuLyViPham = context.Set<HoSoXuLyViPham>();
        _hSXLVP_VanBanGiaiQuyet = context.Set<HSXLVP_VanBanGiaiQuyet>();
    }

    public async Task<PageList<HoSoXuLyViPham>> GetPagedHoSoXuLyViPhamAsync(HoSoXuLyViPhamParameter parameter)
    {
        var query = _hoSoXuLyViPham.Filter(parameter);

        if (!string.IsNullOrEmpty(parameter.OrderBy))
        {
            query = query.OrderBy(parameter.OrderBy);
        }

        if (!string.IsNullOrEmpty(parameter.SearchTerm))
        {
            query = query
                .Where(x => string.IsNullOrEmpty(parameter.SearchTerm)
                    || x.SoHoSo.Contains(parameter.SearchTerm)
                    || x.TenHoSo.Contains(parameter.SearchTerm)
                    || x.ThongTinKhac.Contains(parameter.SearchTerm));
        }

        return await PageList<HoSoXuLyViPham>.ToPageList(query, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<HoSoXuLyViPham> GetHoSoXuLyViPhamById(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task<int> CreateHoSoXuLyViPham(HoSoXuLyViPham request)
    {
        return await CreateAsync(request);
    }

    public async Task UpdateHoSoXuLyViPham(HoSoXuLyViPham request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteHoSoXuLyViPham(HoSoXuLyViPham entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistHoSoXuLyViPham(int id)
    {
        var dks = await FindByCondition(x => x.Id.Equals(id)).ToListAsync();
        return dks != null && dks.Any();
    }
}