namespace NetCoreDemo.Repositories;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;
using Microsoft.EntityFrameworkCore;

public class CategoryRepo : CrudRepo<Category, CategoryDTO>, ICategoryRepo
{
    public CategoryRepo(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async override Task<ICollection<Category>> GetAllAsync(int page, int itemsperpage)
    {
        if(page > 0 && itemsperpage > 0)
        {
            return await _dbContext.Categories.AsNoTracking()
                        .OrderBy(c => c.Id)
                        .Include(i => i.Images)
                        .Skip((page - 1) * itemsperpage)
                        .Take(itemsperpage)
                        .ToListAsync();
        }
        return await _dbContext.Set<Category>().AsNoTracking().ToListAsync();
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