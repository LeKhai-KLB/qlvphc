using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.HoSoXuLyViPhams;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class HSVPVanBanGiaiQuyetRepository : IHSVPVanBanGiaiQuyetRepository
{
    private readonly CatalogServiceContext _context;

    public HSVPVanBanGiaiQuyetRepository(CatalogServiceContext context)
    {
        _context = context;
    }

    public async Task<PageList<HSXLVP_VanBanGiaiQuyet>> GetPagedVanBanByHSVPId(HSVPVanBanGiaiQuyetParameter parameter)
    {
        var query = _context.Set<HSXLVP_VanBanGiaiQuyet>().Filter(parameter);

        if (!string.IsNullOrEmpty(parameter.OrderBy))
        {
            query = query.OrderBy(parameter.OrderBy);
        }

        if (!string.IsNullOrEmpty(parameter.SearchTerm))
        {
            query = query.Where(x => string.IsNullOrEmpty(parameter.SearchTerm)
                || x.SoQuyetDinh.Contains(parameter.SearchTerm));
        }

        return await PageList<HSXLVP_VanBanGiaiQuyet>.ToPageList(query, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<HSXLVP_VanBanGiaiQuyet> GetHSVPVanBanById(int hsId, int vbId)
    {
        return await _context.Set<HSXLVP_VanBanGiaiQuyet>().FirstOrDefaultAsync(x => x.HoSoXuLyViPhamId == hsId && x.VanBanGiaiQuyetId == vbId);
    }

    public async Task CreateHSVPVanBan(HSXLVP_VanBanGiaiQuyet request)
    {
        _context.Set<HSXLVP_VanBanGiaiQuyet>().Add(request);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateHSVPVanBan(HSXLVP_VanBanGiaiQuyet request)
    {
        _context.Set<HSXLVP_VanBanGiaiQuyet>().Update(request);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteHSVPVanBan(HSXLVP_VanBanGiaiQuyet entity)
    {
        _context.Set<HSXLVP_VanBanGiaiQuyet>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> CheckExistHSVPVanBan(int hsId, int vbId)
    {
        var vb = await _context.Set<HSXLVP_VanBanGiaiQuyet>().FirstOrDefaultAsync(x => x.HoSoXuLyViPhamId.Equals(hsId) && x.VanBanGiaiQuyetId.Equals(vbId));
        return vb != null;
    }
}