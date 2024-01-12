using Contracts.Common.Interfaces;
using DanhMucService.Application.Common.Interfaces;
using DanhMucService.Domain.Entities;
using DanhMucService.Infrastructure.Persistence;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DanhMucService.Infrastructure.Repositories;

public class XaPhuongRepository : RepositoryBase<XaPhuong, int, DanhMucServiceContext>, IXaPhuongRepository
{
    public XaPhuongRepository(DanhMucServiceContext context, IUnitOfWork<DanhMucServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        
    }

    
    public async Task<IEnumerable<XaPhuong>> GetXaPhuongByQuanHuyenId(int id)
    {
        var result = FindByCondition(x => x.QuanHuyenId.Equals(id)).OrderBy(x => x.Ten);

        return result;
    }

    public async Task CreateXaPhuong(XaPhuong request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateXaPhuong(XaPhuong request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteXaPhuong(XaPhuong entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistMaDinhDanhXaPhuong(string maDinhDanh)
    {
        var xaPhuong = await FindByCondition(x => x.MaDinhDanh.Equals(maDinhDanh)).ToListAsync();
        return xaPhuong != null && xaPhuong.Any();
    }
}