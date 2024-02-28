using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.ChiTietLinhVucXuPhats;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class ChiTietLinhVucXuPhatRepository : RepositoryBase<ChiTietLinhVucXuPhat, int, CatalogServiceContext>, IChiTietLinhVucXuPhatRepository
{
    private readonly DbSet<ChiTietLinhVucXuPhat> _chiTietLinhVucXuPhat;

    public ChiTietLinhVucXuPhatRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _chiTietLinhVucXuPhat = context.Set<ChiTietLinhVucXuPhat>();
    }

    public async Task<IEnumerable<ChiTietLinhVucXuPhat>> GetChiTietLinhVucXuPhatsByTerm(int linhVucXuPhatId, string? term)
    {
        return await FindByCondition(x => x.LinhVucXuPhatId == linhVucXuPhatId
                && (string.IsNullOrEmpty(term)
                || x.Dieu.Contains(term)
                || x.Khoan.Contains(term)
                || x.Diem.Contains(term)))
            .OrderBy(x => x.Dieu)
            .ThenBy(x => x.Khoan)
            .ToListAsync();
    }

    public async Task<PageList<ChiTietLinhVucXuPhat>> GetPagedByLinhVucXuPhatId(ChiTietLinhVucXuPhatParameter parameter)
    {
        var result = _chiTietLinhVucXuPhat.Filter(parameter).OrderBy(x => x.Dieu).ThenBy(x => x.Khoan);

        return await PageList<ChiTietLinhVucXuPhat>.ToPageList(result, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<ChiTietLinhVucXuPhat> GetChiTietLinhVucXuPhatById(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task CreateChiTietLinhVucXuPhat(ChiTietLinhVucXuPhat request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateChiTietLinhVucXuPhat(ChiTietLinhVucXuPhat request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteChiTietLinhVucXuPhat(ChiTietLinhVucXuPhat entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistChiTietLinhVucXuPhat(int id)
    {
        var chitiet = await FindByCondition(x => x.Id.Equals(id)).ToListAsync();
        return chitiet != null && chitiet.Any();
    }
}