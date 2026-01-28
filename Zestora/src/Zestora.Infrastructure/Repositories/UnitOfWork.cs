using Zestora.Domain.Core.Models;
using Zestora.Domain.Core.Repositories;
using Zestora.Infrastructure.Data;

namespace Zestora.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    protected readonly PostgresContext _dbContext;
    private readonly IDictionary<Type, dynamic> _repositories;

    private ICustomerRepository? _customerRepository;

    public UnitOfWork(PostgresContext dbContext)
    {
        _dbContext = dbContext;
        _repositories = new Dictionary<Type, dynamic>();
    }

    public ICustomerRepository Customer =>
        _customerRepository ??= new CustomerRepository(_dbContext);

    public IBaseRepositoryAsync<T> Repository<T>()
        where T : BaseEntity
    {
        var entityType = typeof(T);

        if (_repositories.ContainsKey(entityType))
        {
            return _repositories[entityType];
        }

        var repositoryType = typeof(BaseRepositoryAsync<>);

        var repository = Activator.CreateInstance(
            repositoryType.MakeGenericType(typeof(T)),
            _dbContext
        );

        if (repository == null)
        {
            throw new NullReferenceException("Repository should not be null");
        }

        _repositories.Add(entityType, repository);

        return (IBaseRepositoryAsync<T>)repository;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public async Task RollBackChangesAsync()
    {
        await _dbContext.Database.RollbackTransactionAsync();
    }
}
