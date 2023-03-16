namespace NetCoreDemo.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreDemo.Db;
using NetCoreDemo.DTOs;
using NetCoreDemo.Models;
using NetCoreDemo.Repositories;

public class CartService : CrudService<Cart, CartDTO>, ICartService
{

    public CartService(AppDbContext dbContext, ICartRepo repo) : base(dbContext, repo)
    {
    }


  public override async Task<Cart?> GetAsync(int id)
  {
      return await _dbContext.Carts
          .Include(p => p.ProductLinks)
          .SingleOrDefaultAsync(p => p.Id == id);
  }

  public async Task<int> AddProductsAsync(int id, ICollection<CartAddProductsDTO> request)
  {
      var cart = await GetAsync(id);
      if (cart is null)
      {
          return -1;
      }
      var productIds = request
      .Select(item => item.ProductId)
      .ToList();

      var products = await _dbContext.Products
          .Where(p => productIds.Contains(p.Id))
          .ToListAsync();

      foreach (var item in request)
      {
          cart.ProductLinks.Add(new CartProduct
          {
              Cart = cart,
              Quantity = item.Quantity,
              ProductId = item.ProductId,
          });
      }
      await _dbContext.SaveChangesAsync();
      return products.Count();
  }
}