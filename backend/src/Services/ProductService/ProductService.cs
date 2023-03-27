namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;
using System.Threading.Tasks;
using System.Collections.Generic;
using NetCoreDemo.Repositories;
using NetCoreDemo.Helpers;

public class ProductService : CrudService<Product, ProductDTO>, IProductService
{
    protected readonly IProductRepo _repo;
    public ProductService(AppDbContext dbContext, IProductRepo repo) : base(dbContext, repo)
    {
      _repo = repo;
    }

    public async override Task<Product?> GetByIdAsync(int id)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity is null)
        {
            throw ServiceException.NotFound("No product in this id");
        }
        return entity;
    }

    public async Task<ICollection<Product>> GetByNameAsync(string name)
    {
        var entity = await _repo.GetByNameAsync(name);
        if (entity.Count == 0)
        {
            throw ServiceException.NotFound("Product not found");
        }
        return entity;
    }

    public async Task<ICollection<Product>> GetByPriceAsync(double price)
    {
        var entity = await _repo.GetByPriceAsync(price);
        if (entity.Count == 0)
        {
            throw ServiceException.NotFound("Product not found");
        }
        return entity;
    }

    public async Task<ICollection<Product>> GetByPriceRangeAsync(double min, double max)
    {
        var entity = await _repo.GetByPriceRangeAsync(min, max);
        if (entity.Count == 0)
        {
            throw ServiceException.NotFound("Product not found");
        }
        return entity;
    }

    public async Task<ICollection<Product>> GetProductsByCategoryAsync(int categoryId)
    {
       var entity = await _repo.GetProductsByCategoryAsync(categoryId);
        if (entity.Count == 0)
        {
            throw ServiceException.NotFound("No Product in this Category");
        }
        return entity;
    }
}