namespace Zestora.Domain.Entities;

public partial class VariantOption
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public Guid? ImageId { get; set; }

    public Guid ProductId { get; set; }

    public decimal SalePrice { get; set; }

    public decimal? ComparePrice { get; set; }

    public decimal? BuyingPrice { get; set; }

    public int Quantity { get; set; }

    public string? Sku { get; set; }

    public bool? Active { get; set; }

    public virtual GalleryPart1? Image { get; set; }

    public virtual GalleryPart3? Image1 { get; set; }

    public virtual GalleryPart2? ImageNavigation { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<Variant> Variants { get; set; } = new List<Variant>();
}
