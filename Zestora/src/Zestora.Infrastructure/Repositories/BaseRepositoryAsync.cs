using Zestora.Domain.Core.Models;
using Zestora.Domain.Core.Repositories;

namespace Zestora.Infrastructure.Repositories;

public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T>
    where T : BaseEntity
{
    public Task<T> AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<T>> ListAllAsync()
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }
}
