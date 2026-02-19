namespace Zestora.Domain.Entities;

public partial class Coupon
{
    public Guid Id { get; set; }

    public string Code { get; set; } = null!;

    public decimal? DiscountValue { get; set; }

    public string DiscountType { get; set; } = null!;

    public decimal TimesUsed { get; set; }

    public decimal? MaxUsage { get; set; }

    public decimal? OrderAmountLimit { get; set; }

    public DateTime? CouponStartDate { get; set; }

    public DateTime? CouponEndDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public virtual StaffAccount? CreatedByNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ProductCoupon> ProductCoupons { get; set; } =
        new List<ProductCoupon>();

    public virtual StaffAccount? UpdatedByNavigation { get; set; }
}
