using System;
using System.Collections.Generic;

namespace Zestora.Infrastructure.Models;

public partial class Supplier
{
    public Guid Id { get; set; }

    public string SupplierName { get; set; } = null!;

    public string? Company { get; set; }

    public string? PhoneNumber { get; set; }

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public int CountryId { get; set; }

    public string? City { get; set; }

    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual StaffAccount? CreatedByNavigation { get; set; }

    public virtual StaffAccount? UpdatedByNavigation { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
