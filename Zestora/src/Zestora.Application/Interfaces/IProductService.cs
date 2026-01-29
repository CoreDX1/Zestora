using Zestora.Application.Models.Requests;
using Zestora.Application.Models.Responses;
using Zestora.Domain.Core.Models;

namespace Zestora.Application.Interfaces;

public interface IProductService
{
    Task<Result<CreateProductResponse>> CreateAsync(CreateProductRequest request);
    Task<IEnumerable<CreateProductResponse>> CreateBulkAsync(CreateBulkProductsRequest request);
    Task<Result<ProductResponse?>> GetByIdAsync(Guid id);
    public Task<Result<List<ProductResponse>>> GetAllAsync();
}
