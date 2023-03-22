namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;
using Microsoft.EntityFrameworkCore;
using NetCoreDemo.Repositories;
using NetCoreDemo.Helpers;

public class CategoryService : CrudService<Category, CategoryDTO>, ICategoryService
{
    protected readonly ICategoryRepo _repo;
    public CategoryService(AppDbContext dbContext, ICategoryRepo repo) : base(dbContext, repo)
    {
        _repo = repo;
    }

    public async override Task<Category?> GetAsync(int id)
    {
        var entity = await _repo.GetAsync(id);
        if (entity is null)
        {
            throw ServiceException.NotFound("Category not found");
        }
        return entity;
    }

    public async override Task<IEnumerable<Category>> GetAllAsync(PaginationParams @params)
    {
        var entity = await _repo.GetAllAsync(@params);
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