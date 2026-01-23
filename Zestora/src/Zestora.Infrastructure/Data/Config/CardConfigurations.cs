using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zestora.Infrastructure.Models;

namespace Zestora.Infrastructure.Data.Config;

public class CardConfigurations : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasKey(e => e.Id).HasName("cards_pkey");

        builder.ToTable("cards");

        builder.HasIndex(e => e.CustomerId, "idx_customer_id_card");

        builder.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
        builder.Property(e => e.CustomerId).HasColumnName("customer_id");

        builder
            .HasOne(d => d.Customer)
            .WithMany(p => p.Cards)
            .HasForeignKey(d => d.CustomerId)
            .HasConstraintName("cards_customer_id_fkey");
    }
}
