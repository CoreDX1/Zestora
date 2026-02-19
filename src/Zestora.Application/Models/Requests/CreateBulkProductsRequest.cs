namespace Zestora.Application.Models.Requests;

/// <summary>
/// Request for creating multiple products in bulk.
/// </summary>
/// <param name="Products">The list of product creation requests.</param>
public record CreateBulkProductsRequest(List<CreateProductRequest> Products);
