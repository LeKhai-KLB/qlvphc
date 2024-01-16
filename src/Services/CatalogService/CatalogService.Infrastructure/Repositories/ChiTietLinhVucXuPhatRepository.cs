using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Repositories;

public class ChiTietLinhVucXuPhatRepository : RepositoryBase<ChiTietLinhVucXuPhat, int, CatalogServiceContext>, IChiTietLinhVucXuPhatRepository
{
    public ChiTietLinhVucXuPhatRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {

    }

    public async Task<IEnumerable<ChiTietLinhVucXuPhat>> GetChiTietByLinhVucXuPhatId(int id)
    {
        var result = FindByCondition(x => x.LinhVucXuPhatId.Equals(id)).OrderBy(x => x.DieuKhoan);

        return result;
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