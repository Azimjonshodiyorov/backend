namespace NetCoreDemo.Repositories;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;

public interface ICategoryRepo : ICrudRepo<Category, CategoryDTO>
{
    Task<ICollection<Category>> GetAllAsync(PaginationParams @params);
    Task<Category?> GetAsync(int id);
    Task<IEnumerable<Product>> GetProductsByCategoryAsync(int id);
}