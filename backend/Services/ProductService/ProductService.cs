namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using NetCoreDemo.Repositories;

public class ProductService : CrudService<Product, ProductDTO>, IProductService
{
    protected readonly IProductRepo _repo;
    public ProductService(AppDbContext dbContext, IProductRepo repo) : base(dbContext, repo)
    {
      _repo = repo;
    }

    public async override Task<Product?> GetAsync(int id)
    {
        var entity = await _repo.GetAsync(id);
        if (entity is null)
        {
            throw new Exception("Item not found");
        }
        return entity;
    }

  public async Task<ICollection<Product>> GetByNameAsync(string name, string keyword)
    {
        var entity = await _repo.GetByNameAsync(name,keyword);
        if (entity is null)
        {
            throw new Exception("Item not found");
        }
        return entity;
    }

    public async Task<ICollection<Product>> GetByPriceAsync(double price)
    {
        var entity = await _repo.GetByPriceAsync(price);
        if (entity is null)
        {
            throw new Exception("Item not found");
        }
        return entity;
    }

    public async Task<ICollection<Product>> GetByPriceRangeAsync(double min, double max)
    {
        var entity = await _repo.GetByPriceRangeAsync(min, max);
        if (entity is null)
        {
            throw new Exception("Item not found");
        }
        return entity;
    }

    public async Task<ICollection<Product>> GetProductsByCategoryAsync(int categoryId)
    {
       var entity = await _repo.GetProductsByCategoryAsync(categoryId);
        if (entity is null)
        {
            throw new Exception("Item not found");
        }
        return entity;
    }
}