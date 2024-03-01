using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.VanBanPhapLuats;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class VanBanPhapLuatRepository : RepositoryBase<VanBanPhapLuat, int, CatalogServiceContext>, IVanBanPhapLuatRepository
{
    private readonly DbSet<VanBanPhapLuat> _vanBanPhapLuat;

    public VanBanPhapLuatRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _vanBanPhapLuat = context.Set<VanBanPhapLuat>();
    }

    public async Task<IEnumerable<VanBanPhapLuat>> GetAllVanBanPhapLuat(bool? isFilterTrichYeu)
    {
        if (isFilterTrichYeu == null || !isFilterTrichYeu.Value)
            return await FindAll().ToListAsync();
        else
            return await FindByCondition(x => !string.IsNullOrEmpty(x.TrichYeuNoiDung))
                .GroupBy(x => x.TrichYeuNoiDung)
                .Select(g => g.OrderBy(x => x.TrichYeuNoiDung).First())
                .ToListAsync();
    }

    public async Task<PageList<VanBanPhapLuat>> GetPagedVanBanPhapLuatAsync(VanBanPhapLuatParameter parameter)
    {
        var query = _vanBanPhapLuat.Filter(parameter);

        if (parameter.NgayBanHanhTu != null)
        {
            query = query.Where(x => x.NgayBanHanh.Date >= parameter.NgayBanHanhTu.Value.Date);
        }

        if (parameter.NgayBanHanhDen != null)
        {
            query = query.Where(x => x.NgayBanHanh.Date <= parameter.NgayBanHanhDen.Value.Date);
        }

        if (!string.IsNullOrEmpty(parameter.OrderBy))
        {
            query = query.OrderBy(parameter.OrderBy);
        }

        if (!string.IsNullOrEmpty(parameter.SearchTerm))
        {
            query = query
                .Include(x => x.LoaiVanBan)
                .Include(x => x.CoQuanBanHanh)
                .Where(x => string.IsNullOrEmpty(parameter.SearchTerm)
                    || x.SoHieu.Contains(parameter.SearchTerm)
                    || x.NgayBanHanh.Year.ToString().Contains(parameter.SearchTerm)
                    || x.NgayBanHanh.Month.ToString().Contains(parameter.SearchTerm)
                    || x.NgayBanHanh.Day.ToString().Contains(parameter.SearchTerm)
                    || x.NgayHieuLuc.Year.ToString().Contains(parameter.SearchTerm)
                    || x.NgayHieuLuc.Month.ToString().Contains(parameter.SearchTerm)
                    || x.NgayHieuLuc.Day.ToString().Contains(parameter.SearchTerm)
                    || (x.TrichYeuNoiDung != null && x.TrichYeuNoiDung.Contains(parameter.SearchTerm))
                    || (x.DuongDanUrl != null && x.DuongDanUrl.Contains(parameter.SearchTerm))
                    || (x.CoQuanBanHanhId != null && x.CoQuanBanHanh.TenCoQuan.Contains(parameter.SearchTerm))
                    || (x.LoaiVanBanId != null && x.LoaiVanBan.Ten.Contains(parameter.SearchTerm)));
        }

        return await PageList<VanBanPhapLuat>.ToPageList(query, parameter.PageNumber, parameter.PageSize);
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