using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zestora.Infrastructure.Models;

namespace Zestora.Infrastructure.Data.Config;

public class AttributeValueConfigurations : IEntityTypeConfiguration<AttributeValue>
{
    public void Configure(EntityTypeBuilder<AttributeValue> builder)
    {
        builder.HasKey(e => e.Id).HasName("attribute_values_pkey");

        builder.ToTable("attribute_values");

        builder.HasIndex(e => e.AttributeId, "idx_attribute_values");

        builder.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
        builder.Property(e => e.AttributeId).HasColumnName("attribute_id");
        builder.Property(e => e.AttributeValue1).HasMaxLength(255).HasColumnName("attribute_value");
        builder
            .Property(e => e.Color)
            .HasMaxLength(50)
            .HasDefaultValueSql("NULL::character varying")
            .HasColumnName("color");

        builder
            .HasOne(d => d.Attribute)
            .WithMany(p => p.AttributeValues)
            .HasForeignKey(d => d.AttributeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("attribute_values_attribute_id_fkey");
    }
}
