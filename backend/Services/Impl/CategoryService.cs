namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;
using Microsoft.EntityFrameworkCore;

public class CategoryService : CrudService<Category, CategoryDTO>, ICategoryService
{

  public CategoryService(AppDbContext dbContext) : base(dbContext)
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

    public async override Task<ICollection<Category>> GetAllAsync(PaginationParams @params)
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

    public async Task<ICollection<Product>> GetProductsAsync(int id)
    {
        var category = await base.GetAsync(id);
        if(category is null) 
        {
           return null;
        }
        var query = _dbContext.Categories.Where(c => c.Id == id).Include(c => c.Products).Select(c => c.Products);
        return (ICollection<Product>)await query.ToListAsync();
        // return await _dbContext.Categories
        //     .Where(c => c.Products.Select(p => p.Id).Contains(id)).ToListAsync();
    }
}