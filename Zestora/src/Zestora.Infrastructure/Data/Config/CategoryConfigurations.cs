using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zestora.Infrastructure.Models;

namespace Zestora.Infrastructure.Data.Config;

public class CategoryConfigurations : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(e => e.Id).HasName("categories_pkey");

        builder.ToTable("categories");

        builder.HasIndex(e => e.CategoryName, "categories_category_name_key").IsUnique();

        builder.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
        builder.Property(e => e.Active).HasDefaultValue(true).HasColumnName("active");
        builder.Property(e => e.CategoryDescription).HasColumnName("category_description");
        builder.Property(e => e.CategoryName).HasMaxLength(255).HasColumnName("category_name");
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("now()").HasColumnName("created_at");
        builder.Property(e => e.CreatedBy).HasColumnName("created_by");
        builder.Property(e => e.Icon).HasColumnName("icon");
        builder.Property(e => e.Image).HasColumnName("image");
        builder.Property(e => e.ParentId).HasColumnName("parent_id");
        builder.Property(e => e.Placeholder).HasColumnName("placeholder");
        builder.Property(e => e.UpdatedAt).HasDefaultValueSql("now()").HasColumnName("updated_at");
        builder.Property(e => e.UpdatedBy).HasColumnName("updated_by");

        builder
            .HasOne(d => d.CreatedByNavigation)
            .WithMany(p => p.CategoryCreatedByNavigations)
            .HasForeignKey(d => d.CreatedBy)
            .HasConstraintName("categories_created_by_fkey");

        builder
            .HasOne(d => d.Parent)
            .WithMany(p => p.InverseParent)
            .HasForeignKey(d => d.ParentId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("categories_parent_id_fkey");

        builder
            .HasOne(d => d.UpdatedByNavigation)
            .WithMany(p => p.CategoryUpdatedByNavigations)
            .HasForeignKey(d => d.UpdatedBy)
            .HasConstraintName("categories_updated_by_fkey");
    }
}
