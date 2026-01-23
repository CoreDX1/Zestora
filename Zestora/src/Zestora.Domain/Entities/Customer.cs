using Zestora.Domain.Core.Models;

namespace Zestora.Domain.Entities;

public partial class Customer : BaseEntity
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public bool? Active { get; set; }

    public DateTime RegisteredAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();

    public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } =
        new List<CustomerAddress>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
