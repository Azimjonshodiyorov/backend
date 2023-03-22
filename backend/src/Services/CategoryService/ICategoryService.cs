namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;

public interface ICategoryService : ICrudService<Category, CategoryDTO>
{
    Task<IEnumerable<Product>> GetProductsByCategoryAsync(int id);
}