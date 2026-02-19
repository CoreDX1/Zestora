namespace Zestora.Domain.Entities;

public partial class CustomerAddress
{
    public Guid Id { get; set; }

    public Guid? CustomerId { get; set; }

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string DialCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string City { get; set; } = null!;

    public virtual Customer? Customer { get; set; }
}
