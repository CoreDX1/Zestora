using System;
using System.Collections.Generic;

namespace Zestora.Infrastructure.Models;

public partial class ShippingRate
{
    public Guid Id { get; set; }

    public int ShippingZoneId { get; set; }

    public string? WeightUnit { get; set; }

    public decimal MinValue { get; set; }

    public decimal? MaxValue { get; set; }

    public bool? NoMax { get; set; }

    public decimal Price { get; set; }

    public virtual ShippingZone ShippingZone { get; set; } = null!;
}
