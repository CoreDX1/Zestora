namespace Zestora.Application.Models.Responses;

/// <summary>
/// Response after successfully creating a product.
/// </summary>
public record CreateProductResponse(
    Guid Id,
    string Slug,
    string ProductName,
    string? Sku,
    decimal SalePrice,
    decimal? ComparePrice,
    int Quantity,
    bool? Published,
    DateTime CreatedAt
);
