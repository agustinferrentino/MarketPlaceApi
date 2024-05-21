using System.Collections.Generic;
using System.Threading.Tasks;
using MarketPlaceApi.Entities;

namespace MarketPlaceApi.Data;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task<Product> GetProductByNameAsync(string name);
    Task UpdateProductAsync(Product product);
}