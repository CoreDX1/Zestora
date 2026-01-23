using System;
using System.Collections.Generic;

namespace Zestora.Infrastructure.Models;

public partial class ProductShippingInfo
{
    public Guid Id { get; set; }

    public Guid? ProductId { get; set; }

    public decimal Weight { get; set; }

    public string? WeightUnit { get; set; }

    public decimal Volume { get; set; }

    public string? VolumeUnit { get; set; }

    public decimal DimensionWidth { get; set; }

    public decimal DimensionHeight { get; set; }

    public decimal DimensionDepth { get; set; }

    public string? DimensionUnit { get; set; }

    public virtual Product? Product { get; set; }
}
