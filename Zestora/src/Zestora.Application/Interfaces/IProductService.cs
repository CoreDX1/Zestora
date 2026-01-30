using Zestora.Application.Models.Requests;
using Zestora.Application.Models.Responses;
using Zestora.Domain.Core.Models;

namespace Zestora.Application.Interfaces;

public interface IProductService
{
    public Task<Result<CreateProductResponse>> CreateAsync(CreateProductRequest request);
    public Task<IEnumerable<CreateProductResponse>> CreateBulkAsync(
        CreateBulkProductsRequest request
    );
    public Task<Result<ProductResponse?>> GetByIdAsync(Guid id);
    public Task<Result<List<ProductResponse>>> GetAllAsync();
}
