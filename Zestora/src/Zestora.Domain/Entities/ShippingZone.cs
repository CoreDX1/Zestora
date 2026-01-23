namespace Zestora.Domain.Entities;

public partial class ShippingZone
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public bool? Active { get; set; }

    public bool? FreeShipping { get; set; }

    public string? RateType { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public virtual StaffAccount? CreatedByNavigation { get; set; }

    public virtual ICollection<ShippingCountryZone> ShippingCountryZones { get; set; } =
        new List<ShippingCountryZone>();

    public virtual ICollection<ShippingRate> ShippingRates { get; set; } = new List<ShippingRate>();

    public virtual StaffAccount? UpdatedByNavigation { get; set; }
}
