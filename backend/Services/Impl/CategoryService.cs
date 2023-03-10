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
        await _dbContext.Entry(category).Collection(s => s.Products).LoadAsync();
        return category;
    }

    public async override Task<ICollection<Category>> GetAllAsync(PaginationParams @params)
    {
        return await _dbContext.Categories.AsNoTracking()
                        .OrderBy(c => c.Id)
                        .Include(c => c.Products)
                        .Skip((@params.Page - 1) * @params.ItemsPerPage)
                        .Take(@params.ItemsPerPage)
                        .ToListAsync();
    }
}