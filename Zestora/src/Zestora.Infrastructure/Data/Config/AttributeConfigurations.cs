using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zestora.Infrastructure.Data.Config;

public class AtributeConfigurations : IEntityTypeConfiguration<Models.Attribute>
{
    public void Configure(EntityTypeBuilder<Models.Attribute> builder)
    {
        builder.HasKey(e => e.Id).HasName("attributes_pkey");

        builder.ToTable("attributes");

        builder.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
        builder.Property(e => e.AttributeName).HasMaxLength(255).HasColumnName("attribute_name");
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("now()").HasColumnName("created_at");
        builder.Property(e => e.CreatedBy).HasColumnName("created_by");
        builder.Property(e => e.UpdatedAt).HasDefaultValueSql("now()").HasColumnName("updated_at");
        builder.Property(e => e.UpdatedBy).HasColumnName("updated_by");

        builder
            .HasOne(d => d.CreatedByNavigation)
            .WithMany(p => p.AttributeCreatedByNavigations)
            .HasForeignKey(d => d.CreatedBy)
            .HasConstraintName("attributes_created_by_fkey");

        builder
            .HasOne(d => d.UpdatedByNavigation)
            .WithMany(p => p.AttributeUpdatedByNavigations)
            .HasForeignKey(d => d.UpdatedBy)
            .HasConstraintName("attributes_updated_by_fkey");
    }
}
