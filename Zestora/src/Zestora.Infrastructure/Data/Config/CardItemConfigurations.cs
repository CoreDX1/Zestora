using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zestora.Infrastructure.Models;

namespace Zestora.Infrastructure.Data.Config;

public class CardItemConfigurations : IEntityTypeConfiguration<CardItem>
{
    public void Configure(EntityTypeBuilder<CardItem> builder)
    {
        builder.HasKey(e => e.Id).HasName("card_items_pkey");

        builder.ToTable("card_items");

        builder.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
        builder.Property(e => e.CardId).HasColumnName("card_id");
        builder.Property(e => e.ProductId).HasColumnName("product_id");
        builder.Property(e => e.Quantity).HasDefaultValue(1).HasColumnName("quantity");

        builder
            .HasOne(d => d.Card)
            .WithMany(p => p.CardItems)
            .HasForeignKey(d => d.CardId)
            .HasConstraintName("card_items_card_id_fkey");

        builder
            .HasOne(d => d.Product)
            .WithMany(p => p.CardItems)
            .HasForeignKey(d => d.ProductId)
            .HasConstraintName("card_items_product_id_fkey");
    }
}
