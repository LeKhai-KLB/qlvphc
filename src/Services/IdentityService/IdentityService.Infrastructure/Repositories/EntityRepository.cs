using IdentityService.Application.Common.Interfaces;
using IdentityService.Infrastructure.Persistence;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace IdentityService.Infrastructure.Repositories;

public class EntityRepository<T, TParameter> : IEntityRepository<T, TParameter> where T : class where TParameter : IPaginationParameters
{
    private readonly ApplicationDbContext _context;

    public EntityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<T> GetByIdAsync(object id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetByTerm(string? term)
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .Where(x => string.IsNullOrEmpty(term)
                || EF.Property<string>(x, "HoTen") != null
                && EF.Property<string>(x, "HoTen").Contains(term)
            )
            .ToListAsync();
    }

    public async Task<PageList<T>> GetPagedAsync(TParameter parameter)
    {
        var result = _context.Set<T>().Filter(parameter);

        return await PageList<T>.ToPageList(result, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        try
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public void Detach(T entity)
    {
        var entry = _context.Entry(entity);
        entry.State = EntityState.Detached;
    }

    private static TValue? GetPropertyValue<TValue>(object obj, string propertyName)
    {
        var property = obj.GetType().GetProperty(propertyName);
        return property != null ? (TValue?)property.GetValue(obj) : default(TValue?);
    }
}