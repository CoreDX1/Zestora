using Zestora.Domain.Core.Models;

namespace Zestora.Domain.Core.Repositories;

public interface IUnitOfWork
{
    ICustomerRepository Customer { get; }

    Task<int> SaveChangesAsync();
    Task RollBackChangesAsync();
    IBaseRepositoryAsync<T> Repository<T>()
        where T : BaseEntity;
}
