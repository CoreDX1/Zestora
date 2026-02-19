using Zestora.Domain.Entities;
using Zestora.Domain.Exceptions;

namespace Zestora.Domain.Builders;

public class CustomerBuilder
{
    private readonly Customer _customer = new();

    public CustomerBuilder WithPersonalData(string firstName, string lastName)
    {
        _customer.FirstName = firstName;
        _customer.LastName = lastName;
        return this;
    }

    public CustomerBuilder WithCredentials(string email, string password)
    {
        _customer.Email = email;
        _customer.PasswordHash = password;
        return this;
    }

    public CustomerBuilder AsActive()
    {
        _customer.Active = true;
        _customer.Id = Guid.NewGuid();
        _customer.RegisteredAt = DateTime.UtcNow;
        _customer.UpdatedAt = DateTime.UtcNow;
        return this;
    }

    public Customer Build()
    {
        // Validaciones de regla de negocio antes de retornar
        if (string.IsNullOrEmpty(_customer.Email))
            throw new DomainException("Email is required");

        return _customer;
    }
}
