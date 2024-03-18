using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.ChiTietHSXLVPVVBGQs;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class ChiTietHSXLVPVVBGQRepository : RepositoryBase<ChiTietHSXLVPVVBGQ, int, CatalogServiceContext>, IChiTietHSXLVPVVBGQRepository
{
    private readonly DbSet<ChiTietHSXLVPVVBGQ> _ChiTietHSXLVPVVBGQ;

    public ChiTietHSXLVPVVBGQRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _ChiTietHSXLVPVVBGQ = context.Set<ChiTietHSXLVPVVBGQ>();
    }

    public async Task<PageList<ChiTietHSXLVPVVBGQ>> GetPagedChiTietHSXLVPVVBGQAsync(ChiTietHSXLVPVVBGQParameter parameter)
    {
        var query = _ChiTietHSXLVPVVBGQ.Filter(parameter);

        if (!string.IsNullOrEmpty(parameter.OrderBy))
        {
            query = query.OrderBy(parameter.OrderBy);
        }

        if (!string.IsNullOrEmpty(parameter.SearchTerm))
        {
            query = query.Where(x => string.IsNullOrEmpty(parameter.SearchTerm)
                || x.SoBB.Contains(parameter.SearchTerm)
                || x.CanCuLapBB.Contains(parameter.SearchTerm)
                || x.DiaDiemLapBB.Contains(parameter.SearchTerm)
                || x.LyDoLapBB.Contains(parameter.SearchTerm)
                || x.CNTCBiThietHai.Contains(parameter.SearchTerm)
                || x.YKienCNTCViPham.Contains(parameter.SearchTerm)
                || x.YKienDaiDienChinhQuyen.Contains(parameter.SearchTerm)
                || x.YKienNguoiChungKien.Contains(parameter.SearchTerm)
                || x.YKienNoiThietHai.Contains(parameter.SearchTerm)
                || x.BienPhapNganChan.Contains(parameter.SearchTerm)
                || x.GhiChu.Contains(parameter.SearchTerm)
                || x.DiaDiemHen.Contains(parameter.SearchTerm)
                || x.LyDoNCKKhongKyBB.Contains(parameter.SearchTerm)
                || x.LyDoKhongKyBB.Contains(parameter.SearchTerm));
        }

        return await PageList<ChiTietHSXLVPVVBGQ>.ToPageList(query, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<ChiTietHSXLVPVVBGQ> GetChiTietHSXLVPVVBGQById(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task CreateChiTietHSXLVPVVBGQ(ChiTietHSXLVPVVBGQ request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateChiTietHSXLVPVVBGQ(ChiTietHSXLVPVVBGQ request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteChiTietHSXLVPVVBGQ(ChiTietHSXLVPVVBGQ entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistChiTietHSXLVPVVBGQ(int id)
    {
        var ChiTietHSXLVPVVBGQs = await FindByCondition(x => x.Id.Equals(id)).ToListAsync();
        return ChiTietHSXLVPVVBGQs != null && ChiTietHSXLVPVVBGQs.Any();
    }
}