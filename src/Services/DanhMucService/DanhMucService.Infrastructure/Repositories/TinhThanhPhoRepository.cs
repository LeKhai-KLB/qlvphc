using Contracts.Common.Interfaces;
using DanhMucService.Application.Common.Interfaces;
using DanhMucService.Application.Parameters.TinhThanhPhos;
using DanhMucService.Domain.Entities;
using DanhMucService.Infrastructure.Persistence;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace DanhMucService.Infrastructure.Repositories;

public class TinhThanhPhoRepository : RepositoryBase<TinhThanhPho, int, DanhMucServiceContext>, ITinhThanhPhoRepository
{
    private readonly DbSet<TinhThanhPho> _tinhthanhpho;
    public TinhThanhPhoRepository(DanhMucServiceContext context, IUnitOfWork<DanhMucServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _tinhthanhpho = context.Set<TinhThanhPho>();
    }

    public async Task<PageList<TinhThanhPho>> GetPagedTinhThanhPhoAsync(TinhThanhPhoParameter parameter)
    {
        var result = _tinhthanhpho.Filter(parameter)
            .OrderBy(x => x.Ten);

        return await PageList<TinhThanhPho>.ToPageList(result, parameter.PageNumber, parameter.PageSize);
    }
    
    public async Task<IEnumerable<TinhThanhPho>> GetTinhThanhPhosByTerm(string? term)
    {
        return await FindByCondition(x => x.IsDeleted == false && string.IsNullOrEmpty(term) || x.Ten.Contains(term)).ToListAsync();
    }

    public async Task CreateTinhThanhPho(TinhThanhPho request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateTinhThanhPho(TinhThanhPho request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteTinhThanhPho(TinhThanhPho entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistMaDiaDanhTinhThanhPho(string maDiaDanh)
    {
        var tinhThanhPho = await FindByCondition(x => x.MaDinhDanh.Equals(maDiaDanh)).ToListAsync();
        return tinhThanhPho != null && tinhThanhPho.Any();
    }
}