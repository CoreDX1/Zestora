using System.ComponentModel;
using Zestora.Domain.Entities;

namespace Zestora.Domain.Core.Repositories;

public interface ICustomerRepository : IBaseRepositoryAsync<Customer>
{
    Task<Customer> GetCustomerByEmail(string email);

    Task<IEnumerable<Customer>> GetAllActiveCustomers();
}
