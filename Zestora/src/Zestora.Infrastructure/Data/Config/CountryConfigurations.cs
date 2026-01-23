using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zestora.Infrastructure.Models;

namespace Zestora.Infrastructure.Data.Config;

public class CountryConfigurations : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(e => e.Id).HasName("countries_pkey");

        builder.ToTable("countries");

        builder
            .Property(e => e.Id)
            .HasDefaultValueSql("nextval('countries_seq'::regclass)")
            .HasColumnName("id");
        builder.Property(e => e.Iso).HasMaxLength(2).IsFixedLength().HasColumnName("iso");
        builder
            .Property(e => e.Iso3)
            .HasMaxLength(3)
            .HasDefaultValueSql("NULL::bpchar")
            .IsFixedLength()
            .HasColumnName("iso3");
        builder.Property(e => e.Name).HasMaxLength(80).HasColumnName("name");
        builder.Property(e => e.NumCode).HasColumnName("num_code");
        builder.Property(e => e.PhoneCode).HasColumnName("phone_code");
        builder.Property(e => e.UpperName).HasMaxLength(80).HasColumnName("upper_name");
    }
}
