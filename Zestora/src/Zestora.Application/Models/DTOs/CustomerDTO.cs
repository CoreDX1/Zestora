using Zestora.Domain.Entities;

namespace Zestora.Application.Models.DTOs;

public class CustomerDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool Active { get; set; }
    public DateTime RegisteredAt { get; set; }

    public CustomerDTO(Customer customer)
    {
        Id = customer.Id;
        FirstName = customer.FirstName;
        LastName = customer.LastName;
        Email = customer.Email;
        Active = customer.Active ?? false;
        RegisteredAt = customer.RegisteredAt;
    }
}
