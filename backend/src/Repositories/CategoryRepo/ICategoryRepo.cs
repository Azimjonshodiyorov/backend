namespace NetCoreDemo.Repositories;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;

public interface ICategoryRepo : ICrudRepo<Category, CategoryDTO>
{
    Task<ICollection<Category>> GetAllAsync(int page, int itemsperpage);
    Task<Category?> GetAsync(int id);
    Task<IEnumerable<Product>> GetProductsByCategoryAsync(int id);
}