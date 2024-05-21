using MarketPlaceApi.Data;
using MarketPlaceApi.Entities;

namespace MarketPlaceApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productRepository.GetProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpGet("name/{name}")]
    public async Task<IActionResult> GetProductByName(string name)
    {
        var product = await _productRepository.GetProductByNameAsync(name);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _productRepository.UpdateProductAsync(product);
        return NoContent();
    }
}

