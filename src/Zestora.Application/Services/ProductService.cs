using System.Text.RegularExpressions;
using AutoMapper;
using Zestora.Application.Interfaces;
using Zestora.Application.Models.Requests;
using Zestora.Application.Models.Responses;
using Zestora.Domain.Builders;
using Zestora.Domain.Core.Models;
using Zestora.Domain.Core.Repositories;

namespace Zestora.Application.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateProductResponse>> CreateAsync(CreateProductRequest request)
    {
        var slug = await GenerateUniqueSlugAsync(request.ProductName);

        var product = new ProductBuilder()
            .WithBasicInfo(
                request.ProductName,
                request.ShortDescription,
                request.ProductDescription
            )
            .WithPricing(request.SalePrice, request.ComparePrice, request.BuyingPrice)
            .WithInventory(request.Quantity, request.Sku)
            .WithSlug(slug)
            .WithType(request.ProductType)
            .AsPublished(request.Published)
            .CreatedBy(request.CreatedBy)
            .Build();

        await _unitOfWork.Product.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<CreateProductResponse>(product);
    }

    public async Task<IEnumerable<CreateProductResponse>> CreateBulkAsync(
        CreateBulkProductsRequest request
    )
    {
        var responses = new List<CreateProductResponse>();

        foreach (var productRequest in request.Products)
        {
            var slug = await GenerateUniqueSlugAsync(productRequest.ProductName);

            var product = new ProductBuilder()
                .WithBasicInfo(
                    productRequest.ProductName,
                    productRequest.ShortDescription,
                    productRequest.ProductDescription
                )
                .WithPricing(
                    productRequest.SalePrice,
                    productRequest.ComparePrice,
                    productRequest.BuyingPrice
                )
                .WithInventory(productRequest.Quantity, productRequest.Sku)
                .WithSlug(slug)
                .WithType(productRequest.ProductType)
                .AsPublished(productRequest.Published)
                .CreatedBy(productRequest.CreatedBy)
                .Build();

            await _unitOfWork.Product.AddAsync(product);

            responses.Add(
                new CreateProductResponse(
                    product.Id,
                    product.Slug,
                    product.ProductName,
                    product.Sku,
                    product.SalePrice,
                    product.ComparePrice,
                    product.Quantity,
                    product.Published,
                    product.CreatedAt
                )
            );
        }

        await _unitOfWork.SaveChangesAsync();
        return responses;
    }

    public async Task<Result<ProductResponse?>> GetByIdAsync(Guid id)
    {
        var product = await _unitOfWork.Product.GetByIdAsync(id);

        if (product == null)
            return Errors.ProductNotFound;

        return _mapper.Map<ProductResponse>(product);
    }

    public async Task<Result<List<ProductResponse>>> GetAllAsync()
    {
        var products = await _unitOfWork.Product.ListAllAsync();

        return _mapper.Map<List<ProductResponse>>(products);
    }

    private async Task<string> GenerateUniqueSlugAsync(string productName)
    {
        var slug = GenerateSlug(productName);
        var originalSlug = slug;
        var counter = 1;

        while (await _unitOfWork.Product.SlugExistsAsync(slug))
        {
            slug = $"{originalSlug}-{counter}";
            counter++;
        }

        return slug;
    }

    private static string GenerateSlug(string text)
    {
        var slug = text.ToLowerInvariant();
        slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");
        slug = Regex.Replace(slug, @"\s+", " ").Trim();
        slug = Regex.Replace(slug, @"\s", "-");
        return slug;
    }
}
