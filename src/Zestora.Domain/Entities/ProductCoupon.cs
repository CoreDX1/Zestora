namespace Zestora.Domain.Entities;

public partial class ProductCoupon
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public Guid CouponId { get; set; }

    public virtual Coupon Coupon { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
