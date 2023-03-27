using NetCoreDemo.DTOs;
using NetCoreDemo.Models;

namespace NetCoreDemo.Services;

public interface IProductService : ICrudService<Product, ProductDTO>
{
    Task<ICollection<Product>> GetByNameAsync(string name);
    Task<ICollection<Product>> GetByPriceAsync(double price);
    Task<ICollection<Product>> GetByPriceRangeAsync(double min, double max);
    Task<ICollection<Product>> GetProductsByCategoryAsync(int categoryId);
}