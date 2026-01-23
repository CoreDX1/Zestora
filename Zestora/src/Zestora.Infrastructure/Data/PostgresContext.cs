using Microsoft.EntityFrameworkCore;
using Zestora.Infrastructure.Models;

namespace Zestora.Infrastructure.Data;

public partial class PostgresContext : DbContext
{
    public PostgresContext() { }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options) { }

    public virtual DbSet<Models.Attribute> Attributes { get; set; }

    public virtual DbSet<AttributeValue> AttributeValues { get; set; }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<CardItem> CardItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<GalleryPart1> GalleryPart1s { get; set; }

    public virtual DbSet<GalleryPart2> GalleryPart2s { get; set; }

    public virtual DbSet<GalleryPart3> GalleryPart3s { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }

    public virtual DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductCoupon> ProductCoupons { get; set; }

    public virtual DbSet<ProductShippingInfo> ProductShippingInfos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sell> Sells { get; set; }

    public virtual DbSet<ShippingCountryZone> ShippingCountryZones { get; set; }

    public virtual DbSet<ShippingRate> ShippingRates { get; set; }

    public virtual DbSet<ShippingZone> ShippingZones { get; set; }

    public virtual DbSet<Slideshow> Slideshows { get; set; }

    public virtual DbSet<StaffAccount> StaffAccounts { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Variant> Variants { get; set; }

    public virtual DbSet<VariantOption> VariantOptions { get; set; }

    public virtual DbSet<VariantValue> VariantValues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseNpgsql(
            "Host=localhost:5433;Database=postgres;Username=crud_user;Password=crud_password"
        );

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Models.Attribute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("attributes_pkey");

            entity.ToTable("attributes");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.AttributeName).HasMaxLength(255).HasColumnName("attribute_name");
            entity
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity
                .HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.AttributeCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("attributes_created_by_fkey");

            entity
                .HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.AttributeUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("attributes_updated_by_fkey");
        });

        modelBuilder.Entity<AttributeValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("attribute_values_pkey");

            entity.ToTable("attribute_values");

            entity.HasIndex(e => e.AttributeId, "idx_attribute_values");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.AttributeId).HasColumnName("attribute_id");
            entity
                .Property(e => e.AttributeValue1)
                .HasMaxLength(255)
                .HasColumnName("attribute_value");
            entity
                .Property(e => e.Color)
                .HasMaxLength(50)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("color");

            entity
                .HasOne(d => d.Attribute)
                .WithMany(p => p.AttributeValues)
                .HasForeignKey(d => d.AttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("attribute_values_attribute_id_fkey");
        });

        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cards_pkey");

            entity.ToTable("cards");

            entity.HasIndex(e => e.CustomerId, "idx_customer_id_card");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");

            entity
                .HasOne(d => d.Customer)
                .WithMany(p => p.Cards)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("cards_customer_id_fkey");
        });

        modelBuilder.Entity<CardItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("card_items_pkey");

            entity.ToTable("card_items");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasDefaultValue(1).HasColumnName("quantity");

            entity
                .HasOne(d => d.Card)
                .WithMany(p => p.CardItems)
                .HasForeignKey(d => d.CardId)
                .HasConstraintName("card_items_card_id_fkey");

            entity
                .HasOne(d => d.Product)
                .WithMany(p => p.CardItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("card_items_product_id_fkey");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.HasIndex(e => e.CategoryName, "categories_category_name_key").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.Active).HasDefaultValue(true).HasColumnName("active");
            entity.Property(e => e.CategoryDescription).HasColumnName("category_description");
            entity.Property(e => e.CategoryName).HasMaxLength(255).HasColumnName("category_name");
            entity
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Icon).HasColumnName("icon");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.Placeholder).HasColumnName("placeholder");
            entity
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity
                .HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.CategoryCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("categories_created_by_fkey");

            entity
                .HasOne(d => d.Parent)
                .WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("categories_parent_id_fkey");

            entity
                .HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.CategoryUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("categories_updated_by_fkey");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("countries_pkey");

            entity.ToTable("countries");

            entity
                .Property(e => e.Id)
                .HasDefaultValueSql("nextval('countries_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Iso).HasMaxLength(2).IsFixedLength().HasColumnName("iso");
            entity
                .Property(e => e.Iso3)
                .HasMaxLength(3)
                .HasDefaultValueSql("NULL::bpchar")
                .IsFixedLength()
                .HasColumnName("iso3");
            entity.Property(e => e.Name).HasMaxLength(80).HasColumnName("name");
            entity.Property(e => e.NumCode).HasColumnName("num_code");
            entity.Property(e => e.PhoneCode).HasColumnName("phone_code");
            entity.Property(e => e.UpperName).HasMaxLength(80).HasColumnName("upper_name");
        });

        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("coupons_pkey");

            entity.ToTable("coupons");

            entity.HasIndex(e => e.Code, "coupons_code_key").IsUnique();

            entity.HasIndex(e => e.Code, "idx_code_coupons");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.Code).HasMaxLength(50).HasColumnName("code");
            entity.Property(e => e.CouponEndDate).HasColumnName("coupon_end_date");
            entity.Property(e => e.CouponStartDate).HasColumnName("coupon_start_date");
            entity
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DiscountType).HasMaxLength(50).HasColumnName("discount_type");
            entity.Property(e => e.DiscountValue).HasColumnName("discount_value");
            entity.Property(e => e.MaxUsage).HasColumnName("max_usage");
            entity.Property(e => e.OrderAmountLimit).HasColumnName("order_amount_limit");
            entity.Property(e => e.TimesUsed).HasColumnName("times_used");
            entity
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity
                .HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.CouponCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("coupons_created_by_fkey");

            entity
                .HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.CouponUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("coupons_updated_by_fkey");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customers_pkey");

            entity.ToTable("customers");

            entity.HasIndex(e => e.Email, "customers_email_key").IsUnique();

            entity.HasIndex(e => e.Email, "idx_customer_email");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.Active).HasDefaultValue(true).HasColumnName("active");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FirstName).HasMaxLength(100).HasColumnName("first_name");
            entity.Property(e => e.LastName).HasMaxLength(100).HasColumnName("last_name");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
            entity
                .Property(e => e.RegisteredAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("registered_at");
            entity
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customer_addresses_pkey");

            entity.ToTable("customer_addresses");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.AddressLine1).HasColumnName("address_line1");
            entity.Property(e => e.AddressLine2).HasColumnName("address_line2");
            entity.Property(e => e.City).HasMaxLength(255).HasColumnName("city");
            entity.Property(e => e.Country).HasMaxLength(255).HasColumnName("country");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.DialCode).HasMaxLength(100).HasColumnName("dial_code");
            entity.Property(e => e.PhoneNumber).HasMaxLength(255).HasColumnName("phone_number");
            entity.Property(e => e.PostalCode).HasMaxLength(255).HasColumnName("postal_code");

            entity
                .HasOne(d => d.Customer)
                .WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("customer_addresses_customer_id_fkey");
        });

        modelBuilder.Entity<GalleryPart1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("gallery_part1_pkey");

            entity.ToTable("gallery_part1");

            entity.HasIndex(
                e => new { e.ProductId, e.IsThumbnail },
                "gallery_part1_product_id_is_thumbnail_idx"
            );

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Image).HasColumnName("image");
            entity
                .Property(e => e.IsThumbnail)
                .HasDefaultValue(false)
                .HasColumnName("is_thumbnail");
            entity.Property(e => e.Placeholder).HasColumnName("placeholder");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity
                .HasOne(d => d.Product)
                .WithMany(p => p.GalleryPart1s)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("gallery_product_id_fkey");
        });

        modelBuilder.Entity<GalleryPart2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("gallery_part2_pkey");

            entity.ToTable("gallery_part2");

            entity.HasIndex(
                e => new { e.ProductId, e.IsThumbnail },
                "gallery_part2_product_id_is_thumbnail_idx"
            );

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Image).HasColumnName("image");
            entity
                .Property(e => e.IsThumbnail)
                .HasDefaultValue(false)
                .HasColumnName("is_thumbnail");
            entity.Property(e => e.Placeholder).HasColumnName("placeholder");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity
                .HasOne(d => d.Product)
                .WithMany(p => p.GalleryPart2s)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("gallery_product_id_fkey");
        });

        modelBuilder.Entity<GalleryPart3>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("gallery_part3_pkey");

            entity.ToTable("gallery_part3");

            entity.HasIndex(
                e => new { e.ProductId, e.IsThumbnail },
                "gallery_part3_product_id_is_thumbnail_idx"
            );

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Image).HasColumnName("image");
            entity
                .Property(e => e.IsThumbnail)
                .HasDefaultValue(false)
                .HasColumnName("is_thumbnail");
            entity.Property(e => e.Placeholder).HasColumnName("placeholder");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity
                .HasOne(d => d.Product)
                .WithMany(p => p.GalleryPart3s)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("gallery_product_id_fkey");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("notifications_pkey");

            entity.ToTable("notifications");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity
                .Property(e => e.NotificationExpiryDate)
                .HasColumnName("notification_expiry_date");
            entity.Property(e => e.ReceiveTime).HasColumnName("receive_time");
            entity.Property(e => e.Seen).HasColumnName("seen");
            entity.Property(e => e.Title).HasMaxLength(100).HasColumnName("title");

            entity
                .HasOne(d => d.Account)
                .WithMany(p => p.Notifications)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("notifications_account_id_fkey");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.HasIndex(e => e.CustomerId, "idx_order_customer_id");

            entity.Property(e => e.Id).HasMaxLength(50).HasColumnName("id");
            entity.Property(e => e.CouponId).HasColumnName("coupon_id");
            entity
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.OrderApprovedAt).HasColumnName("order_approved_at");
            entity
                .Property(e => e.OrderDeliveredCarrierDate)
                .HasColumnName("order_delivered_carrier_date");
            entity
                .Property(e => e.OrderDeliveredCustomerDate)
                .HasColumnName("order_delivered_customer_date");
            entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity
                .HasOne(d => d.Coupon)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CouponId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("orders_coupon_id_fkey");

            entity
                .HasOne(d => d.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("orders_customer_id_fkey");

            entity
                .HasOne(d => d.OrderStatus)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("orders_order_status_id_fkey");

            entity
                .HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("orders_updated_by_fkey");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_items_pkey");

            entity.ToTable("order_items");

            entity.HasIndex(e => e.OrderId, "idx_order_id_order_item");

            entity.HasIndex(e => e.ProductId, "idx_product_id_order_item");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.OrderId).HasMaxLength(50).HasColumnName("order_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity
                .HasOne(d => d.Order)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("order_items_order_id_fkey");

            entity
                .HasOne(d => d.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("order_items_product_id_fkey");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_statuses_pkey");

            entity.ToTable("order_statuses");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.Color).HasMaxLength(50).HasColumnName("color");
            entity
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity
                .Property(e => e.Privacy)
                .HasMaxLength(10)
                .HasDefaultValueSql("'private'::character varying")
                .HasColumnName("privacy");
            entity.Property(e => e.StatusName).HasMaxLength(255).HasColumnName("status_name");
            entity
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity
                .HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.OrderStatusCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("order_statuses_created_by_fkey");

            entity
                .HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.OrderStatusUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("order_statuses_updated_by_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pkey");

            entity.ToTable("products");

            entity.HasIndex(e => e.Published, "idx_product_publish");

            entity.HasIndex(e => e.Slug, "products_slug_key").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.BuyingPrice).HasColumnName("buying_price");
            entity.Property(e => e.ComparePrice).HasDefaultValue(0m).HasColumnName("compare_price");
            entity
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity
                .Property(e => e.DisableOutOfStock)
                .HasDefaultValue(true)
                .HasColumnName("disable_out_of_stock");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.ProductDescription).HasColumnName("product_description");
            entity.Property(e => e.ProductName).HasMaxLength(255).HasColumnName("product_name");
            entity.Property(e => e.ProductType).HasMaxLength(64).HasColumnName("product_type");
            entity.Property(e => e.Published).HasDefaultValue(false).HasColumnName("published");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SalePrice).HasColumnName("sale_price");
            entity
                .Property(e => e.ShortDescription)
                .HasMaxLength(165)
                .HasColumnName("short_description");
            entity.Property(e => e.Sku).HasMaxLength(255).HasColumnName("sku");
            entity.Property(e => e.Slug).HasColumnName("slug");
            entity
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity
                .HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.ProductCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("products_created_by_fkey");

            entity
                .HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.ProductUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("products_updated_by_fkey");

            entity
                .HasMany(d => d.Suppliers)
                .WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductSupplier",
                    r =>
                        r.HasOne<Supplier>()
                            .WithMany()
                            .HasForeignKey("SupplierId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("product_suppliers_supplier_id_fkey"),
                    l =>
                        l.HasOne<Product>()
                            .WithMany()
                            .HasForeignKey("ProductId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("product_suppliers_product_id_fkey"),
                    j =>
                    {
                        j.HasKey("ProductId", "SupplierId").HasName("product_suppliers_pkey");
                        j.ToTable("product_suppliers");
                        j.HasIndex(new[] { "ProductId", "SupplierId" }, "idx_product_supplier");
                        j.IndexerProperty<Guid>("ProductId").HasColumnName("product_id");
                        j.IndexerProperty<Guid>("SupplierId").HasColumnName("supplier_id");
                    }
                );
        });

        modelBuilder.Entity<ProductAttribute>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_attributes_pkey");

            entity.ToTable("product_attributes");

            entity.HasIndex(e => new { e.ProductId, e.AttributeId }, "idx_product_attribute_fk");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.AttributeId).HasColumnName("attribute_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity
                .HasOne(d => d.Attribute)
                .WithMany(p => p.ProductAttributes)
                .HasForeignKey(d => d.AttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_attributes_attribute_id_fkey");

            entity
                .HasOne(d => d.Product)
                .WithMany(p => p.ProductAttributes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_attributes_product_id_fkey");
        });

        modelBuilder.Entity<ProductAttributeValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_attribute_values_pkey");

            entity.ToTable("product_attribute_values");

            entity.HasIndex(
                e => e.AttributeValueId,
                "idx_product_attribute_values_attribute_value_id"
            );

            entity.HasIndex(
                e => e.ProductAttributeId,
                "idx_product_attribute_values_product_attribute_id"
            );

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.AttributeValueId).HasColumnName("attribute_value_id");
            entity.Property(e => e.ProductAttributeId).HasColumnName("product_attribute_id");

            entity
                .HasOne(d => d.AttributeValue)
                .WithMany(p => p.ProductAttributeValues)
                .HasForeignKey(d => d.AttributeValueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_attribute_values_attribute_value_id_fkey");

            entity
                .HasOne(d => d.ProductAttribute)
                .WithMany(p => p.ProductAttributeValues)
                .HasForeignKey(d => d.ProductAttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_attribute_values_product_attribute_id_fkey");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_categories_pkey");

            entity.ToTable("product_categories");

            entity.HasIndex(e => new { e.ProductId, e.CategoryId }, "idx_product_category");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity
                .HasOne(d => d.Category)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_categories_category_id_fkey");

            entity
                .HasOne(d => d.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_categories_product_id_fkey");
        });

        modelBuilder.Entity<ProductCoupon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_coupons_pkey");

            entity.ToTable("product_coupons");

            entity.HasIndex(
                e => new { e.ProductId, e.CouponId },
                "idx_product_id_coupon_id_product_coupons"
            );

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.CouponId).HasColumnName("coupon_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity
                .HasOne(d => d.Coupon)
                .WithMany(p => p.ProductCoupons)
                .HasForeignKey(d => d.CouponId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_coupons_coupon_id_fkey");

            entity
                .HasOne(d => d.Product)
                .WithMany(p => p.ProductCoupons)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_coupons_product_id_fkey");
        });

        modelBuilder.Entity<ProductShippingInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_shipping_info_pkey");

            entity.ToTable("product_shipping_info");

            entity.HasIndex(e => e.ProductId, "idx_product_shipping_info_product_id");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.DimensionDepth).HasColumnName("dimension_depth");
            entity.Property(e => e.DimensionHeight).HasColumnName("dimension_height");
            entity.Property(e => e.DimensionUnit).HasMaxLength(10).HasColumnName("dimension_unit");
            entity.Property(e => e.DimensionWidth).HasColumnName("dimension_width");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Volume).HasColumnName("volume");
            entity.Property(e => e.VolumeUnit).HasMaxLength(10).HasColumnName("volume_unit");
            entity.Property(e => e.Weight).HasColumnName("weight");
            entity.Property(e => e.WeightUnit).HasMaxLength(10).HasColumnName("weight_unit");

            entity
                .HasOne(d => d.Product)
                .WithMany(p => p.ProductShippingInfos)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_shipping_info_product_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Privileges).HasColumnName("privileges");
            entity.Property(e => e.RoleName).HasMaxLength(255).HasColumnName("role_name");
        });

        modelBuilder.Entity<Sell>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sells_pkey");

            entity.ToTable("sells");

            entity.HasIndex(e => e.ProductId, "sells_product_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity
                .HasOne(d => d.Product)
                .WithOne(p => p.Sell)
                .HasForeignKey<Sell>(d => d.ProductId)
                .HasConstraintName("sells_product_id_fkey");
        });

        modelBuilder.Entity<ShippingCountryZone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shipping_country_zones_pkey");

            entity.ToTable("shipping_country_zones");

            entity.HasIndex(e => e.CountryId, "idx_country_id_shipping_country_zones");

            entity.HasIndex(e => e.ShippingZoneId, "idx_shipping_zone_id_shipping_country_zones");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.ShippingZoneId).HasColumnName("shipping_zone_id");

            entity
                .HasOne(d => d.Country)
                .WithMany(p => p.ShippingCountryZones)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("shipping_country_zones_country_id_fkey");

            entity
                .HasOne(d => d.ShippingZone)
                .WithMany(p => p.ShippingCountryZones)
                .HasForeignKey(d => d.ShippingZoneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("shipping_country_zones_shipping_zone_id_fkey");
        });

        modelBuilder.Entity<ShippingRate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shipping_rates_pkey");

            entity.ToTable("shipping_rates");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.MaxValue).HasColumnName("max_value");
            entity.Property(e => e.MinValue).HasColumnName("min_value");
            entity.Property(e => e.NoMax).HasDefaultValue(true).HasColumnName("no_max");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ShippingZoneId).HasColumnName("shipping_zone_id");
            entity.Property(e => e.WeightUnit).HasMaxLength(10).HasColumnName("weight_unit");

            entity
                .HasOne(d => d.ShippingZone)
                .WithMany(p => p.ShippingRates)
                .HasForeignKey(d => d.ShippingZoneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("shipping_rates_shipping_zone_id_fkey");
        });

        modelBuilder.Entity<ShippingZone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shipping_zones_pkey");

            entity.ToTable("shipping_zones");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasDefaultValue(false).HasColumnName("active");
            entity
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DisplayName).HasMaxLength(255).HasColumnName("display_name");
            entity
                .Property(e => e.FreeShipping)
                .HasDefaultValue(false)
                .HasColumnName("free_shipping");
            entity.Property(e => e.Name).HasMaxLength(255).HasColumnName("name");
            entity.Property(e => e.RateType).HasMaxLength(64).HasColumnName("rate_type");
            entity
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity
                .HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.ShippingZoneCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("shipping_zones_created_by_fkey");

            entity
                .HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.ShippingZoneUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("shipping_zones_updated_by_fkey");
        });

        modelBuilder.Entity<Slideshow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("slideshows_pkey");

            entity.ToTable("slideshows");

            entity.HasIndex(e => e.Published, "idx_slideshows_publish");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.BtnLabel).HasMaxLength(50).HasColumnName("btn_label");
            entity.Property(e => e.Clicks).HasColumnName("clicks");
            entity
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description).HasMaxLength(160).HasColumnName("description");
            entity.Property(e => e.DestinationUrl).HasColumnName("destination_url");
            entity.Property(e => e.DisplayOrder).HasColumnName("display_order");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Placeholder).HasColumnName("placeholder");
            entity.Property(e => e.Published).HasDefaultValue(false).HasColumnName("published");
            entity.Property(e => e.Styles).HasColumnType("jsonb").HasColumnName("styles");
            entity.Property(e => e.Title).HasMaxLength(80).HasColumnName("title");
            entity
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity
                .HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.SlideshowCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("slideshows_created_by_fkey");

            entity
                .HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.SlideshowUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("slideshows_updated_by_fkey");
        });

        modelBuilder.Entity<StaffAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("staff_accounts_pkey");

            entity.ToTable("staff_accounts");

            entity.HasIndex(e => e.Email, "staff_accounts_email_key").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.Active).HasDefaultValue(true).HasColumnName("active");
            entity
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Email).HasMaxLength(255).HasColumnName("email");
            entity.Property(e => e.FirstName).HasMaxLength(100).HasColumnName("first_name");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.LastName).HasMaxLength(100).HasColumnName("last_name");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
            entity
                .Property(e => e.PhoneNumber)
                .HasMaxLength(100)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("phone_number");
            entity.Property(e => e.Placeholder).HasColumnName("placeholder");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity
                .HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.InverseCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("staff_accounts_created_by_fkey");

            entity
                .HasOne(d => d.Role)
                .WithMany(p => p.StaffAccounts)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("staff_accounts_role_id_fkey");

            entity
                .HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.InverseUpdatedByNavigation)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("staff_accounts_updated_by_fkey");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("suppliers_pkey");

            entity.ToTable("suppliers");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.AddressLine1).HasColumnName("address_line1");
            entity.Property(e => e.AddressLine2).HasColumnName("address_line2");
            entity.Property(e => e.City).HasMaxLength(255).HasColumnName("city");
            entity.Property(e => e.Company).HasMaxLength(255).HasColumnName("company");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.PhoneNumber).HasMaxLength(255).HasColumnName("phone_number");
            entity.Property(e => e.SupplierName).HasMaxLength(255).HasColumnName("supplier_name");
            entity
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity
                .HasOne(d => d.Country)
                .WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("suppliers_country_id_fkey");

            entity
                .HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.SupplierCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("suppliers_created_by_fkey");

            entity
                .HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.SupplierUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("suppliers_updated_by_fkey");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tags_pkey");

            entity.ToTable("tags");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Icon).HasColumnName("icon");
            entity.Property(e => e.TagName).HasMaxLength(255).HasColumnName("tag_name");
            entity
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity
                .HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.TagCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("tags_created_by_fkey");

            entity
                .HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.TagUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("tags_updated_by_fkey");

            entity
                .HasMany(d => d.Products)
                .WithMany(p => p.Tags)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductTag",
                    r =>
                        r.HasOne<Product>()
                            .WithMany()
                            .HasForeignKey("ProductId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("product_tags_product_id_fkey"),
                    l =>
                        l.HasOne<Tag>()
                            .WithMany()
                            .HasForeignKey("TagId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("product_tags_tag_id_fkey"),
                    j =>
                    {
                        j.HasKey("TagId", "ProductId").HasName("product_tags_pkey");
                        j.ToTable("product_tags");
                        j.IndexerProperty<Guid>("TagId").HasColumnName("tag_id");
                        j.IndexerProperty<Guid>("ProductId").HasColumnName("product_id");
                    }
                );
        });

        modelBuilder.Entity<Variant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("variants_pkey");

            entity.ToTable("variants");

            entity.HasIndex(e => e.ProductId, "idx_product_id_variants");

            entity.HasIndex(e => e.VariantOptionId, "idx_variant_option_id_variants");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.VariantOption).HasColumnName("variant_option");
            entity.Property(e => e.VariantOptionId).HasColumnName("variant_option_id");

            entity
                .HasOne(d => d.Product)
                .WithMany(p => p.Variants)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("variants_product_id_fkey");

            entity
                .HasOne(d => d.VariantOptionNavigation)
                .WithMany(p => p.Variants)
                .HasForeignKey(d => d.VariantOptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("variants_variant_option_id_fkey");
        });

        modelBuilder.Entity<VariantOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("variant_options_pkey");

            entity.ToTable("variant_options");

            entity.HasIndex(e => e.ProductId, "idx_variant_options_product_id");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity.Property(e => e.Active).HasDefaultValue(true).HasColumnName("active");
            entity.Property(e => e.BuyingPrice).HasColumnName("buying_price");
            entity.Property(e => e.ComparePrice).HasDefaultValue(0m).HasColumnName("compare_price");
            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SalePrice).HasColumnName("sale_price");
            entity.Property(e => e.Sku).HasMaxLength(255).HasColumnName("sku");
            entity.Property(e => e.Title).HasColumnName("title");

            entity
                .HasOne(d => d.Image)
                .WithMany(p => p.VariantOptions)
                .HasForeignKey(d => d.ImageId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("variant_options_image_id_fkey_1");

            entity
                .HasOne(d => d.ImageNavigation)
                .WithMany(p => p.VariantOptions)
                .HasForeignKey(d => d.ImageId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("variant_options_image_id_fkey_2");

            entity
                .HasOne(d => d.Image1)
                .WithMany(p => p.VariantOptions)
                .HasForeignKey(d => d.ImageId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("variant_options_image_id_fkey_3");

            entity
                .HasOne(d => d.Product)
                .WithMany(p => p.VariantOptions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("variant_options_product_id_fkey");
        });

        modelBuilder.Entity<VariantValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("variant_values_pkey");

            entity.ToTable("variant_values");

            entity.HasIndex(
                e => e.ProductAttributeValueId,
                "idx_product_attribute_value_id_variant_values"
            );

            entity.HasIndex(e => e.VariantId, "idx_variant_id_variant_values");

            entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()").HasColumnName("id");
            entity
                .Property(e => e.ProductAttributeValueId)
                .HasColumnName("product_attribute_value_id");
            entity.Property(e => e.VariantId).HasColumnName("variant_id");

            entity
                .HasOne(d => d.ProductAttributeValue)
                .WithMany(p => p.VariantValues)
                .HasForeignKey(d => d.ProductAttributeValueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("variant_values_product_attribute_value_id_fkey");

            entity
                .HasOne(d => d.Variant)
                .WithMany(p => p.VariantValues)
                .HasForeignKey(d => d.VariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("variant_values_variant_id_fkey");
        });
        modelBuilder.HasSequence("countries_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
