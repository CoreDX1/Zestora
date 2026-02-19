namespace Zestora.Domain.Entities;

public partial class GalleryPart1
{
    public Guid Id { get; set; }

    public Guid? ProductId { get; set; }

    public string Image { get; set; } = null!;

    public string Placeholder { get; set; } = null!;

    public bool? IsThumbnail { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ICollection<VariantOption> VariantOptions { get; set; } =
        new List<VariantOption>();
}
