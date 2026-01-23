namespace Zestora.Domain.Entities;

public partial class Slideshow
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public string? DestinationUrl { get; set; }

    public string Image { get; set; } = null!;

    public string Placeholder { get; set; } = null!;

    public string? Description { get; set; }

    public string? BtnLabel { get; set; }

    public int DisplayOrder { get; set; }

    public bool? Published { get; set; }

    public int Clicks { get; set; }

    public string? Styles { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public virtual StaffAccount? CreatedByNavigation { get; set; }

    public virtual StaffAccount? UpdatedByNavigation { get; set; }
}
