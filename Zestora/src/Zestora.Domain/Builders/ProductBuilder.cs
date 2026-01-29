using Zestora.Domain.Entities;
using Zestora.Domain.Exceptions;

namespace Zestora.Domain.Builders;

public class ProductBuilder
{
    private readonly Product _product = new();

    public ProductBuilder WithBasicInfo(
        string productName,
        string shortDescription,
        string productDescription
    )
    {
        _product.ProductName = productName;
        _product.ShortDescription = shortDescription;
        _product.ProductDescription = productDescription;
        return this;
    }

    public ProductBuilder WithPricing(
        decimal salePrice,
        decimal? comparePrice = null,
        decimal? buyingPrice = null
    )
    {
        _product.SalePrice = salePrice;
        _product.ComparePrice = comparePrice;
        _product.BuyingPrice = buyingPrice;
        return this;
    }

    public ProductBuilder WithInventory(int quantity, string? sku = null)
    {
        _product.Quantity = quantity;
        _product.Sku = sku;
        return this;
    }

    public ProductBuilder WithSlug(string slug)
    {
        _product.Slug = slug;
        return this;
    }

    public ProductBuilder WithType(string? productType)
    {
        _product.ProductType = productType;
        return this;
    }

    public ProductBuilder AsPublished(bool published = true)
    {
        _product.Published = published;
        _product.Id = Guid.NewGuid();
        _product.DisableOutOfStock = true;
        _product.CreatedAt = DateTime.UtcNow;
        _product.UpdatedAt = DateTime.UtcNow;
        return this;
    }

    public ProductBuilder CreatedBy(Guid? userId)
    {
        _product.CreatedBy = userId;
        return this;
    }

    public Product Build()
    {
        if (string.IsNullOrEmpty(_product.ProductName))
            throw new DomainException("Product name is required");

        if (string.IsNullOrEmpty(_product.Slug))
            throw new DomainException("Product slug is required");

        if (_product.SalePrice <= 0)
            throw new DomainException("Sale price must be greater than zero");

        return _product;
    }
}
