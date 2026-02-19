namespace Zestora.Application.Models.Requests;

/// <summary>
/// Request for creating a new product.
/// </summary>
public record CreateProductRequest(
    string ProductName,
    decimal SalePrice,
    int Quantity,
    string ShortDescription,
    string ProductDescription,
    string? Sku = null,
    decimal? ComparePrice = null,
    decimal? BuyingPrice = null,
    string? ProductType = null,
    bool Published = false,
    Guid? CreatedBy = null
);
