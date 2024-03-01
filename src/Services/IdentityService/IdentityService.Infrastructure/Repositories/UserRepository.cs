using IdentityService.Application.Common.Interfaces;
using IdentityService.Application.Parameters.Users;
using IdentityService.Domain.Entities;
using IdentityService.Infrastructure.Persistence;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;
using System.Linq.Expressions;

namespace IdentityService.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetByIdAsync(object id)
    {
        return await _context.Set<User>().FindAsync(id);
    }

    public async Task<PageList<User>> GetPagedAsync(UserParameter parameter, List<string> propertiesToCheck)
    {
        var query = _context.Set<User>().Filter(parameter);

        if (!string.IsNullOrEmpty(parameter.OrderBy))
        {
            query = query.OrderBy(parameter.OrderBy);
        }

        if (!string.IsNullOrEmpty(parameter.SearchTerm))
        {
            var userParams = Expression.Parameter(typeof(User), "x");
            var termExpression = Expression.Constant(parameter.SearchTerm);

            var body = propertiesToCheck
                .Select(propertyName =>
                    Expression.AndAlso(
                        Expression.NotEqual(
                            Expression.Call(typeof(EF), "Property", new[] { typeof(string) }, userParams, Expression.Constant(propertyName)),
                            Expression.Constant(null)
                        ),
                        Expression.Call(
                            Expression.Call(typeof(EF), "Property", new[] { typeof(string) }, userParams, Expression.Constant(propertyName)),
                            typeof(string).GetMethod("Contains", new[] { typeof(string) }),
                            termExpression
                        )
                    )
                )
                .Aggregate(Expression.OrElse);

            var whereClause = Expression.Lambda<Func<User, bool>>(body, userParams);

            query = query.Where(whereClause);
        }

        return await PageList<User>.ToPageList(query, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<bool> UpdateAsync(User entity)
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

    public void Detach(User entity)
    {
        var entry = _context.Entry(entity);
        entry.State = EntityState.Detached;
    }
}