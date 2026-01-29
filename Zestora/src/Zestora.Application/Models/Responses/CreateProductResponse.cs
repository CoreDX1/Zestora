namespace Zestora.Application.Models.Responses;

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
