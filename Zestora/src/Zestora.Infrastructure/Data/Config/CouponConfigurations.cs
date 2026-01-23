using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zestora.Infrastructure.Models;

namespace Zestora.Infrastructure.Data.Config;

public class CouponConfigurations : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.HasKey(e => e.Id).HasName("coupons_pkey");

        builder.ToTable("coupons");

        builder.HasIndex(e => e.Code, "coupons_code_key").IsUnique();

        builder.HasIndex(e => e.Code, "idx_code_coupons");

        builder.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
        builder.Property(e => e.Code).HasMaxLength(50).HasColumnName("code");
        builder.Property(e => e.CouponEndDate).HasColumnName("coupon_end_date");
        builder.Property(e => e.CouponStartDate).HasColumnName("coupon_start_date");
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("now()").HasColumnName("created_at");
        builder.Property(e => e.CreatedBy).HasColumnName("created_by");
        builder.Property(e => e.DiscountType).HasMaxLength(50).HasColumnName("discount_type");
        builder.Property(e => e.DiscountValue).HasColumnName("discount_value");
        builder.Property(e => e.MaxUsage).HasColumnName("max_usage");
        builder.Property(e => e.OrderAmountLimit).HasColumnName("order_amount_limit");
        builder.Property(e => e.TimesUsed).HasColumnName("times_used");
        builder.Property(e => e.UpdatedAt).HasDefaultValueSql("now()").HasColumnName("updated_at");
        builder.Property(e => e.UpdatedBy).HasColumnName("updated_by");

        builder
            .HasOne(d => d.CreatedByNavigation)
            .WithMany(p => p.CouponCreatedByNavigations)
            .HasForeignKey(d => d.CreatedBy)
            .HasConstraintName("coupons_created_by_fkey");

        builder
            .HasOne(d => d.UpdatedByNavigation)
            .WithMany(p => p.CouponUpdatedByNavigations)
            .HasForeignKey(d => d.UpdatedBy)
            .HasConstraintName("coupons_updated_by_fkey");
    }
}
