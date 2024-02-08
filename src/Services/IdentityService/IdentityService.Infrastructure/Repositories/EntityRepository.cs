using IdentityService.Application.Common.Interfaces;
using IdentityService.Infrastructure.Persistence;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;
using System.Linq.Expressions;

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

    public async Task<IEnumerable<T>> GetByTerm(string? term, List<string> propertiesToCheck)
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        var termExpression = Expression.Constant(term);

        var body = propertiesToCheck
            .Select(propertyName =>
                Expression.AndAlso(
                    Expression.NotEqual(
                        Expression.Call(typeof(EF), "Property", new[] { typeof(string) }, parameter, Expression.Constant(propertyName)),
                        Expression.Constant(null)
                    ),
                    Expression.Call(
                        Expression.Call(typeof(EF), "Property", new[] { typeof(string) }, parameter, Expression.Constant(propertyName)),
                        typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                        termExpression
                    )
                )
            )
            .Aggregate(Expression.OrElse);

        var whereClause = Expression.Lambda<Func<T, bool>>(body, parameter);

        return await _context.Set<T>()
            .AsNoTracking()
            .Where(whereClause)
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