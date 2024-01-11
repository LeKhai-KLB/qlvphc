using Contracts.Common.Interfaces;
using DanhMucService.Application.Common.Interfaces;
using DanhMucService.Domain.Entities;
using DanhMucService.Infrastructure.Persistence;
using Infrastructure.Common;
using Infrastructure.Extensions;

namespace DanhMucService.Infrastructure.Repositories;

public class XaPhuongRepository : RepositoryBase<XaPhuong, int, DanhMucServiceContext>, IXaPhuongRepository
{
    public XaPhuongRepository(DanhMucServiceContext context, IUnitOfWork<DanhMucServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        
    }

    
    public async Task<IEnumerable<XaPhuong>> GetXaPhuong()
    {
        var result = FindAll().OrderBy(x => x.Ten);

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
}