using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.CongDans;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class CongDanRepository : RepositoryBase<CongDan, int, CatalogServiceContext>, ICongDanRepository
{
    private readonly DbSet<CongDan> _CongDan;

    public CongDanRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _CongDan = context.Set<CongDan>();
    }

    public async Task<IEnumerable<CongDan>> GetAllCongDans()
    {
        return await FindAll().ToListAsync();
    }

    public async Task<PageList<CongDan>> GetPagedCongDanAsync(CongDanParameter parameter)
    {
        var query = _CongDan.Filter(parameter);

        if (!string.IsNullOrEmpty(parameter.OrderBy))
        {
            query = query.OrderBy(parameter.OrderBy);
        }

        if (!string.IsNullOrEmpty(parameter.SearchTerm))
        {
            query = query.Where(x => string.IsNullOrEmpty(parameter.SearchTerm)
                || x.HoTen.Contains(parameter.SearchTerm)
                || x.QuocTich.Contains(parameter.SearchTerm)
                || x.NgheNghiep.Contains(parameter.SearchTerm)
                || x.QueQuan.Contains(parameter.SearchTerm)
                || x.DiaChi.Contains(parameter.SearchTerm)
                || x.SoLoaiGiayTo.Contains(parameter.SearchTerm)
                || x.NoiCap.Contains(parameter.SearchTerm)
                || x.HocVan.Contains(parameter.SearchTerm)
                || x.DienThoai.Contains(parameter.SearchTerm)
                || x.TenGoiKhac.Contains(parameter.SearchTerm)
                || x.Email.Contains(parameter.SearchTerm)
                || x.NoiLamViec.Contains(parameter.SearchTerm));
        }

        return await PageList<CongDan>.ToPageList(query, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<CongDan> GetCongDanById(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task CreateCongDan(CongDan request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateCongDan(CongDan request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteCongDan(CongDan entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistCongDan(int id)
    {
        var CongDans = await FindByCondition(x => x.Id.Equals(id)).ToListAsync();
        return CongDans != null && CongDans.Any();
    }
}