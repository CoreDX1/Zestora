using Zestora.Domain.Core.Models;

namespace Zestora.Domain.Core.Repositories;

public interface IBaseRepositoryAsync<T>
    where T : BaseEntity
{
    Task<T> GetByIdAsync(Guid id);
    Task<IList<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}
