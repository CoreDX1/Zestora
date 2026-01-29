using Zestora.Domain.Entities;

namespace Zestora.Domain.Core.Repositories;

public interface IProductRepository : IBaseRepositoryAsync<Product>
{
    Task<bool> SlugExistsAsync(string slug);
}
