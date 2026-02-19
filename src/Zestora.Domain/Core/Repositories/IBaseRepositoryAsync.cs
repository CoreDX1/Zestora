using Zestora.Domain.Core.Models;
using Zestora.Domain.Core.Specifications;

namespace Zestora.Domain.Core.Repositories;

public interface IBaseRepositoryAsync<T>
    where T : BaseEntity
{
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task<T?> FirstOrDefaultAsync(ISpecification<T?> spec);
    void Update(T entity);
    void Delete(T entity);
}
