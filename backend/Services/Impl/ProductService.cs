namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;

public class ProductService : CrudService<Product, ProductDTO>
{
  public ProductService(AppDbContext dbContext) : base(dbContext)
  {
  }
}