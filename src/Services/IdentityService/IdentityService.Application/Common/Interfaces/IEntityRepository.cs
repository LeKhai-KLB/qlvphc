using Shared.SeedWord;

namespace IdentityService.Application.Common.Interfaces;

public interface IEntityRepository<T, TParameter> where T : class
{
    Task<T> GetByIdAsync(object id);

    Task<IEnumerable<T>> GetByTerm(string? term);

    Task<PageList<T>> GetPagedAsync(TParameter parameter);

    Task<bool> UpdateAsync(T entity);

    void Detach(T entity);
}