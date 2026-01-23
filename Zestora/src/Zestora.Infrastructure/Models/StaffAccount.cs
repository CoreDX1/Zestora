using System;
using System.Collections.Generic;

namespace Zestora.Infrastructure.Models;

public partial class StaffAccount
{
    public Guid Id { get; set; }

    public int? RoleId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public bool? Active { get; set; }

    public string? Image { get; set; }

    public string? Placeholder { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public virtual ICollection<Attribute> AttributeCreatedByNavigations { get; set; } = new List<Attribute>();

    public virtual ICollection<Attribute> AttributeUpdatedByNavigations { get; set; } = new List<Attribute>();

    public virtual ICollection<Category> CategoryCreatedByNavigations { get; set; } = new List<Category>();

    public virtual ICollection<Category> CategoryUpdatedByNavigations { get; set; } = new List<Category>();

    public virtual ICollection<Coupon> CouponCreatedByNavigations { get; set; } = new List<Coupon>();

    public virtual ICollection<Coupon> CouponUpdatedByNavigations { get; set; } = new List<Coupon>();

    public virtual StaffAccount? CreatedByNavigation { get; set; }

    public virtual ICollection<StaffAccount> InverseCreatedByNavigation { get; set; } = new List<StaffAccount>();

    public virtual ICollection<StaffAccount> InverseUpdatedByNavigation { get; set; } = new List<StaffAccount>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<OrderStatus> OrderStatusCreatedByNavigations { get; set; } = new List<OrderStatus>();

    public virtual ICollection<OrderStatus> OrderStatusUpdatedByNavigations { get; set; } = new List<OrderStatus>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Product> ProductCreatedByNavigations { get; set; } = new List<Product>();

    public virtual ICollection<Product> ProductUpdatedByNavigations { get; set; } = new List<Product>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<ShippingZone> ShippingZoneCreatedByNavigations { get; set; } = new List<ShippingZone>();

    public virtual ICollection<ShippingZone> ShippingZoneUpdatedByNavigations { get; set; } = new List<ShippingZone>();

    public virtual ICollection<Slideshow> SlideshowCreatedByNavigations { get; set; } = new List<Slideshow>();

    public virtual ICollection<Slideshow> SlideshowUpdatedByNavigations { get; set; } = new List<Slideshow>();

    public virtual ICollection<Supplier> SupplierCreatedByNavigations { get; set; } = new List<Supplier>();

    public virtual ICollection<Supplier> SupplierUpdatedByNavigations { get; set; } = new List<Supplier>();

    public virtual ICollection<Tag> TagCreatedByNavigations { get; set; } = new List<Tag>();

    public virtual ICollection<Tag> TagUpdatedByNavigations { get; set; } = new List<Tag>();

    public virtual StaffAccount? UpdatedByNavigation { get; set; }
}
