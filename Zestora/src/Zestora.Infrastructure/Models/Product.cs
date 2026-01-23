using System;
using System.Collections.Generic;

namespace Zestora.Infrastructure.Models;

public partial class Product
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

    public virtual ICollection<CardItem> CardItems { get; set; } = new List<CardItem>();

    public virtual StaffAccount? CreatedByNavigation { get; set; }

    public virtual ICollection<GalleryPart1> GalleryPart1s { get; set; } = new List<GalleryPart1>();

    public virtual ICollection<GalleryPart2> GalleryPart2s { get; set; } = new List<GalleryPart2>();

    public virtual ICollection<GalleryPart3> GalleryPart3s { get; set; } = new List<GalleryPart3>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

    public virtual ICollection<ProductCoupon> ProductCoupons { get; set; } = new List<ProductCoupon>();

    public virtual ICollection<ProductShippingInfo> ProductShippingInfos { get; set; } = new List<ProductShippingInfo>();

    public virtual Sell? Sell { get; set; }

    public virtual StaffAccount? UpdatedByNavigation { get; set; }

    public virtual ICollection<VariantOption> VariantOptions { get; set; } = new List<VariantOption>();

    public virtual ICollection<Variant> Variants { get; set; } = new List<Variant>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
