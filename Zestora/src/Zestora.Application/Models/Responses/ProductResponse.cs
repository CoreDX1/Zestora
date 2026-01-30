namespace Zestora.Application.Models.Responses;

/// <summary>
/// Response containing product information.
/// </summary>
public record ProductResponse(
    Guid Id,
    string Slug,
    string ProductName,
    string? Sku,
    decimal SalePrice,
    decimal? ComparePrice,
    decimal? BuyingPrice,
    int Quantity,
    string ShortDescription,
    string ProductDescription,
    string? ProductType,
    bool? Published,
    DateTime CreatedAt
);
