namespace NetCoreDemo.Repositories;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;

public interface IProductRepo : ICrudRepo<Product, ProductDTO>
{
    Task<ICollection<Product>> GetByNameAsync(string name, string keyword);
    Task<ICollection<Product>> GetByPriceAsync(double price);
    Task<ICollection<Product>> GetByPriceRangeAsync(double min, double max);
    Task<ICollection<Product>> GetProductsByCategoryAsync(int categoryId);

}