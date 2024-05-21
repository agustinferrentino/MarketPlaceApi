using Microsoft.AspNetCore.Mvc;
using MarketPlaceApi.Data;
using MarketPlaceApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPlaceApi.Controllers
{
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
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<Product>> GetProductByName(string name)
        {
            var product = await _productRepository.GetProductByNameAsync(name);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product updatedProduct)
        {
            if (id != updatedProduct.Id)
            {
                return BadRequest();
            }

            var product = await _productRepository.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            product.ProductCode = updatedProduct.ProductCode;
            product.Title = updatedProduct.Title;
            product.OriginalPrice = updatedProduct.OriginalPrice;
            product.Price = updatedProduct.Price;
            product.Commission = updatedProduct.Commission;
            product.ShippingCost = updatedProduct.ShippingCost;
            product.IsActive = updatedProduct.IsActive;

            if (product.ProductCost != null)
            {
                product.ProductCost.ProductCode = updatedProduct.ProductCost.ProductCode;
                product.ProductCost.IVA = updatedProduct.ProductCost.IVA;
                product.ProductCost.Cost = updatedProduct.ProductCost.Cost;
            }
            else
            {
                product.ProductCost = updatedProduct.ProductCost;
            }

            await _productRepository.UpdateProductAsync(product);

            return NoContent();
        }
    }
}
