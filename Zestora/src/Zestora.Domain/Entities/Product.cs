using Zestora.Domain.Core.Models;

namespace Zestora.Domain.Entities;

public partial class Product : BaseEntity
{
    public Guid Id { get; set; }

    public string Slug { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string? Sku { get; set; }

    public decimal SalePrice { get; set; }

    public decimal? ComparePrice { get; set; }

    public decimal? BuyingPrice { get; set; }

    public int Quantity { get; set; }

    public string ShortDescription { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public string? ProductType { get; set; }

    public bool? Published { get; set; }

    public bool? DisableOutOfStock { get; set; }

    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public virtual ICollection<CardItem> CardItems { get; set; } = [];

    public virtual StaffAccount? CreatedByNavigation { get; set; }

    public virtual ICollection<GalleryPart1> GalleryPart1s { get; set; } = [];

    public virtual ICollection<GalleryPart2> GalleryPart2s { get; set; } = [];

    public virtual ICollection<GalleryPart3> GalleryPart3s { get; set; } = [];

    public virtual ICollection<OrderItem> OrderItems { get; set; } = [];

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = [];

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = [];

    public virtual ICollection<ProductCoupon> ProductCoupons { get; set; } = [];

    public virtual ICollection<ProductShippingInfo> ProductShippingInfos { get; set; } = [];

    public virtual Sell? Sell { get; set; }

    public virtual StaffAccount? UpdatedByNavigation { get; set; }

    public virtual ICollection<VariantOption> VariantOptions { get; set; } = [];

    public virtual ICollection<Variant> Variants { get; set; } = [];

    public virtual ICollection<Supplier> Suppliers { get; set; } = [];

    public virtual ICollection<Tag> Tags { get; set; } = [];
}
