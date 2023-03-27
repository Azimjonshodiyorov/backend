namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;
using NetCoreDemo.Repositories;
using NetCoreDemo.Helpers;

public class CategoryService : CrudService<Category, CategoryDTO>, ICategoryService
{
    protected readonly ICategoryRepo _repo;
    public CategoryService(AppDbContext dbContext, ICategoryRepo repo) : base(dbContext, repo)
    {
        _repo = repo;
    }

    public async override Task<Category?> GetByIdAsync(int id)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity is null)
        {
            throw ServiceException.NotFound("Category not found");
        }
        return entity;
    }

    public async override Task<IEnumerable<Category>> GetAllAsync(int page, int itemsperpage)
    {
        var entity = await _repo.GetAllAsync(page, itemsperpage);
        if (entity is null)
        {
            throw ServiceException.NotFound("Category not found");
        }
        return entity;
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int id)
    {
        var entity = await _repo.GetProductsByCategoryAsync(id);
        if (entity is null)
        {
            throw ServiceException.NotFound("No products in this Category");
        }
        return entity;
    }
}