using System;
using System.Collections.Generic;

namespace Zestora.Infrastructure.Models;

public partial class ShippingCountryZone
{
    public Guid Id { get; set; }

    public int ShippingZoneId { get; set; }

    public int CountryId { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ShippingZone ShippingZone { get; set; } = null!;
}
