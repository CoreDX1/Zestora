using Microsoft.AspNetCore.Mvc;
using Zestora.Application.Interfaces;
using Zestora.Application.Models.Requests;

namespace Zestora.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
    {
        var response = await _productService.CreateAsync(request);

        if (response.Error != null)
        {
            return BadRequest(response.Error);
        }

        return Ok(response.Value);
    }

    [HttpPost("bulk")]
    public async Task<IActionResult> CreateBulk([FromBody] CreateBulkProductsRequest request)
    {
        var response = await _productService.CreateBulkAsync(request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _productService.GetByIdAsync(id);

        if (response.Error != null)
        {
            return BadRequest(response.Error);
        }

        return Ok(response.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _productService.GetAllAsync();
        if (response.Error != null)
        {
            return BadRequest(response.Error);
        }

        return Ok(response);
    }
}
