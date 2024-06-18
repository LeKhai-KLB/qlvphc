using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.HoSoXuLyViPhams;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Polly;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class HoSoXuLyViPham_VanBanGiaiQuyetRepository : RepositoryBase<HoSoXuLyViPham_VanBanGiaiQuyet, int, CatalogServiceContext>, IHoSoXuLyViPham_VanBanGiaiQuyetRepository
{
    private readonly CatalogServiceContext _context;

    public HoSoXuLyViPham_VanBanGiaiQuyetRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _context = context;
    }

    public async Task<PageList<HoSoXuLyViPham_VanBanGiaiQuyet>> GetPagedVanBanByHSVPId(HSVPVanBanGiaiQuyetParameter parameter)
    {
        var query = _context.Set<HoSoXuLyViPham_VanBanGiaiQuyet>().Filter(parameter);

        if (!string.IsNullOrEmpty(parameter.OrderBy))
        {
            query = query.OrderBy(parameter.OrderBy);
        }

        if (!string.IsNullOrEmpty(parameter.SearchTerm))
        {
            query = query.Where(x => string.IsNullOrEmpty(parameter.SearchTerm)
                || x.SoQuyetDinh.Contains(parameter.SearchTerm));
        }

        return await PageList<HoSoXuLyViPham_VanBanGiaiQuyet>.ToPageList(query, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<HoSoXuLyViPham_VanBanGiaiQuyet> GetHoSoXuLyViPham_VanBanQiaiQuyetById(int hsId, int vbId)
    {
        return await _context.Set<HoSoXuLyViPham_VanBanGiaiQuyet>().FirstOrDefaultAsync(x => x.HoSoXuLyViPhamId == hsId && x.VanBanGiaiQuyetId == vbId);
    }

    public async Task CreateHSVPVanBan(HoSoXuLyViPham_VanBanGiaiQuyet request)
    {
        _context.Set<HoSoXuLyViPham_VanBanGiaiQuyet>().Add(request);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateHoSoXuLyViPham_VanBanGiaiQuyet(HoSoXuLyViPham_VanBanGiaiQuyet request)
    {
        _context.Set<HoSoXuLyViPham_VanBanGiaiQuyet>().Update(request);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteHSVPVanBan(HoSoXuLyViPham_VanBanGiaiQuyet entity)
    {
        _context.Set<HoSoXuLyViPham_VanBanGiaiQuyet>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> CheckExistHSVPVanBan(int hsId, int vbId)
    {
        var vb = await _context.Set<HoSoXuLyViPham_VanBanGiaiQuyet>().FirstOrDefaultAsync(x => x.HoSoXuLyViPhamId.Equals(hsId) && x.VanBanGiaiQuyetId.Equals(vbId));
        return vb != null;
    }

    public async Task<List<HoSoXuLyViPham_VanBanGiaiQuyet>> GetHoSoXuLyViPham_VanBanGiaiQuyetsByHoSoXuLyViPhamId(int hsxlvpId)
    {
        var result = await FindByCondition(x => x.HoSoXuLyViPhamId == hsxlvpId).ToListAsync();
        return result;
    }
}