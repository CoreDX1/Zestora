using Microsoft.EntityFrameworkCore;
using Zestora.Domain.Core.Models;
using Zestora.Domain.Core.Repositories;
using Zestora.Domain.Core.Specifications;
using Zestora.Infrastructure.Data;

namespace Zestora.Infrastructure.Repositories;

public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T>
    where T : BaseEntity
{
    private readonly PostgresContext _dbContext;
    protected readonly DbSet<T> _dbSet;

    public BaseRepositoryAsync(PostgresContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<T?> FirstOrDefaultAsync(ISpecification<T?> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> ListAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
    }
}
