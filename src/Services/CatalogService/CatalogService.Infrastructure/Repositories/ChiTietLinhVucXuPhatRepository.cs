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

    public async Task<PageList<ChiTietLinhVucXuPhat>> GetPagedByLinhVucXuPhatId(ChiTietLinhVucXuPhatParameter parameter)
    {
        var query = _chiTietLinhVucXuPhat.Filter(parameter);

        if (!string.IsNullOrEmpty(parameter.OrderBy))
        {
            query = query.OrderBy(parameter.OrderBy);
        }

        if (!string.IsNullOrEmpty(parameter.SearchTerm))
        {
            query = query.Where(x => string.IsNullOrEmpty(parameter.SearchTerm)
                || x.Dieu.Contains(parameter.SearchTerm)
                || x.Khoan.Contains(parameter.SearchTerm)
                || x.Diem.Contains(parameter.SearchTerm));
        }
        
        return await PageList<ChiTietLinhVucXuPhat>.ToPageList(query, parameter.PageNumber, parameter.PageSize);
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