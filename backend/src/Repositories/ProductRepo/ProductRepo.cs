namespace NetCoreDemo.Repositories;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class ProductRepo : CrudRepo<Product, ProductDTO>, IProductRepo
{
    public ProductRepo(AppDbContext dbContext) : base(dbContext)
    {
    }

  public async override Task<Product?> GetByIdAsync(int id)
    {
        var product = await base.GetByIdAsync(id);
        if (product is null)
        {
          return null;
        }
        await _dbContext.Entry(product).Reference(s => s.Category).LoadAsync();
        return product;
    }

    public async Task<ICollection<Product>> GetByNameAsync(string name)
    {
        var query = _dbContext.Products.Where(c => true);

        if (name is not null && !string.IsNullOrEmpty(name))
        {
          query = query.Where(c => c.Name.ToLower().Contains(name.ToLower()));
        }
        return await query.OrderByDescending(c => c.CreatedAt).Include(p => p.Category).ToListAsync();
    }

    public async Task<ICollection<Product>> GetByPriceAsync(double price)
    {
        var query = _dbContext.Products.Where(c => true);
        query = query.Where(c => c.Price == price);

        return await query.OrderByDescending(c => c.CreatedAt).Include(p => p.Category).ToListAsync();
    }

    public async Task<ICollection<Product>> GetByPriceRangeAsync(double min, double max)
    {
        var query = _dbContext.Products.Where(c => true);
        query = query.Where(c => c.Price >= min && c.Price <= max);

        return await query.OrderByDescending(c => c.CreatedAt).Include(p => p.Category).ToListAsync();
    }

    public async Task<ICollection<Product>> GetProductsByCategoryAsync(int categoryId)
    {
        var query = _dbContext.Products.Where(p => true);
        query = query.Where(p => p.CategoryId == categoryId);

        return await query.OrderByDescending(c => c.CreatedAt).ToListAsync();
    }
}