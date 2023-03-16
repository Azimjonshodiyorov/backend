namespace NetCoreDemo.Repositories;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;

public class CartRepo : CrudRepo<Cart, CartDTO>, ICartRepo
{
  public CartRepo(AppDbContext dbContext) : base(dbContext)
  {
  }
}