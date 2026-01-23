using System;
using System.Collections.Generic;

namespace Zestora.Infrastructure.Models;

public partial class Order
{
    public string Id { get; set; } = null!;

    public Guid? CouponId { get; set; }

    public Guid? CustomerId { get; set; }

    public Guid? OrderStatusId { get; set; }

    public DateTime? OrderApprovedAt { get; set; }

    public DateTime? OrderDeliveredCarrierDate { get; set; }

    public DateTime? OrderDeliveredCustomerDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid? UpdatedBy { get; set; }

    public virtual Coupon? Coupon { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual OrderStatus? OrderStatus { get; set; }

    public virtual StaffAccount? UpdatedByNavigation { get; set; }
}
