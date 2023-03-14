namespace NetCoreDemo.Repositories;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;

public class ProductRepo : CrudRepo<Product, ProductDTO>, IProductRepo
{
  public ProductRepo(AppDbContext dbContext) : base(dbContext)
  {
  }
}