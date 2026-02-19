using Microsoft.EntityFrameworkCore;
using Zestora.Domain.Core.Repositories;
using Zestora.Domain.Entities;
using Zestora.Infrastructure.Data;

namespace Zestora.Infrastructure.Repositories;

public class ProductRepository : BaseRepositoryAsync<Product>, IProductRepository
{
    public ProductRepository(PostgresContext dbContext)
        : base(dbContext) { }

    public async Task<bool> SlugExistsAsync(string slug)
    {
        return await _dbSet.AnyAsync(p => p.Slug == slug);
    }
}
