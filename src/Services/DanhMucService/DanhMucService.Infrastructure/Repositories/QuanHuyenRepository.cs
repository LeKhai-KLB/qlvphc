using Contracts.Common.Interfaces;
using DanhMucService.Application.Common.Interfaces;
using DanhMucService.Domain.Entities;
using DanhMucService.Infrastructure.Persistence;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DanhMucService.Infrastructure.Repositories;

public class QuanHuyenRepository : RepositoryBase<QuanHuyen, int, DanhMucServiceContext>, IQuanHuyenRepository
{
    public QuanHuyenRepository(DanhMucServiceContext context, IUnitOfWork<DanhMucServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        
    }

    
    public async Task<IEnumerable<QuanHuyen>> GetQuanHuyenByTinhThanhPhoId(int id)
    {
        var result = FindByCondition(x => x.TinhThanhPhoId.Equals(id)).OrderBy(x => x.Ten);

        return result;
    }

    public async Task CreateQuanHuyen(QuanHuyen request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateQuanHuyen(QuanHuyen request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteQuanHuyen(QuanHuyen entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistMaDinhDanhQuanHuyen(string maDinhDanh)
    {
        var quanHuyen = await FindByCondition(x => x.MaDinhDanh.Equals(maDinhDanh)).ToListAsync();
        return quanHuyen != null && quanHuyen.Any();
    }
}