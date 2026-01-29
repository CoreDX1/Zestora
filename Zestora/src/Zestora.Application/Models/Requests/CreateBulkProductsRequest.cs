namespace Zestora.Application.Models.Requests;

public record CreateBulkProductsRequest(
    List<CreateProductRequest> Products
);
