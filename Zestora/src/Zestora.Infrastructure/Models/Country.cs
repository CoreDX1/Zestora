using System;
using System.Collections.Generic;

namespace Zestora.Infrastructure.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Iso { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string UpperName { get; set; } = null!;

    public string? Iso3 { get; set; }

    public short? NumCode { get; set; }

    public int PhoneCode { get; set; }

    public virtual ICollection<ShippingCountryZone> ShippingCountryZones { get; set; } = new List<ShippingCountryZone>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
