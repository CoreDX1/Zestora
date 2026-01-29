using Zestora.Application.Models.Requests;
using Zestora.Application.Models.Responses;

namespace Zestora.Application.Interfaces;

public interface IProductService
{
    Task<CreateProductResponse> CreateAsync(CreateProductRequest request);
    Task<IEnumerable<CreateProductResponse>> CreateBulkAsync(CreateBulkProductsRequest request);
    Task<ProductResponse?> GetByIdAsync(Guid id);
    Task<IEnumerable<ProductResponse>> GetAllAsync();
}
