using Microsoft.EntityFrameworkCore;
using Zestora.Domain.Core.Repositories;
using Zestora.Domain.Entities;
using Zestora.Infrastructure.Data;

namespace Zestora.Infrastructure.Repositories;

public class CustomerRepository : BaseRepositoryAsync<Customer>, ICustomerRepository
{
    public CustomerRepository(PostgresContext dbContext)
        : base(dbContext) { }

    public async Task<IEnumerable<Customer>> GetAllActiveCustomers()
    {
        return await _dbSet.Where(c => c.Active == true).ToListAsync();
    }

    public async Task<Customer> GetCustomerByEmail(string email)
    {
        var customer = await _dbSet.FirstOrDefaultAsync(c => c.Email == email & c.Active == true);

        if (customer != null)
        {
            return customer;
        }

        return null!;
    }
}
