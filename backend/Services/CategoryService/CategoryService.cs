namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;
using Microsoft.EntityFrameworkCore;
using NetCoreDemo.Repositories;

public class CategoryService : CrudService<Category, CategoryDTO>, ICategoryService
{

  public CategoryService(AppDbContext dbContext, ICategoryRepo repo) : base(dbContext, repo)
    {
    }

    public async override Task<Category?> GetAsync(int id)
    {
        var category = await base.GetAsync(id);
        if(category is null) 
        {
            return null;
        }
        await _dbContext.Entry(category).Collection(p => p.Products).LoadAsync();
        await _dbContext.Entry(category).Reference(p => p.Images).LoadAsync();

        return category;
    }

    public async override Task<IEnumerable<Category>> GetAllAsync(PaginationParams @params)
    {
        if(@params is null)
        {
            return await _dbContext.Set<Category>().AsNoTracking().ToListAsync();
        }
        return await _dbContext.Categories.AsNoTracking()
                        .OrderBy(c => c.Id)
                        .Include(i => i.Images)
                        .Skip((@params.Page - 1) * @params.ItemsPerPage)
                        .Take(@params.ItemsPerPage)
                        .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int id)
    {
        var category = await base.GetAsync(id);
        if(category is null) 
        {
           return null;
        }
        var query = _dbContext.Categories.Include(c => c.Products).FirstOrDefault(c => c.Id == id);
        if(query is null)
        {
            return null;
        }
        return query.Products;
    }
}