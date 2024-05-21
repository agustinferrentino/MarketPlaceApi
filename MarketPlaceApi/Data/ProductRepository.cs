using System.Collections.Generic;
using System.Threading.Tasks;
using MarketPlaceApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketPlaceApi.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketplaceContext _context;

        public ProductRepository(MarketplaceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.ProductCost) 
                .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductCost) 
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            return await _context.Products
                .Include(p => p.ProductCost)
                .FirstOrDefaultAsync(p => p.Title == name);
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}