namespace NetCoreDemo.Repositories;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class OrderRepo : CrudRepo<Order, OrderDTO>, IOrderRepo
{
  public OrderRepo(AppDbContext dbContext) : base(dbContext)
  {
  }

public override async Task<Order?> GetAsync(int id)
  {
    return await _dbContext.Orders
        .Include(p => p.ProductLinks)
        .SingleOrDefaultAsync(p => p.Id == id);
  }



    public async Task<int> AddProductsAsync(int id, ICollection<OrderAddProductsDTO> request)
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


        // foreach (var item in request)
        // {
        //     var isCartIdExist = _dbContext.CartProducts.Where(cart => cart.CartId == id && cart.ProductId == item.ProductId).ToList();

        //     if (isCartIdExist == null)
        //     {
        //         cart.ProductLinks.Add(new CartProduct
        //         {
        //         Cart = cart,
        //         Quantity = item.Quantity,
        //         ProductId = item.ProductId,
        //         });
        //         await _dbContext.SaveChangesAsync();
        //         return products.Count();
        //     }
        //     return 1;
        // }


        // foreach( var proId in productIds)
        // {
        // if(_dbContext.CartProducts.Where(cart => cart.CartId == id && cart.ProductId == proId )! == null)
        // {
        //     return 1234;
        // }
        foreach (var item in request)
            {
                cart.ProductLinks.Add(new OrderProduct
                {
                    Order = cart,
                    Quantity = item.Quantity,
                    ProductId = item.ProductId,
                });
            }

        await _dbContext.SaveChangesAsync();
        return products.Count();
    }


    public async Task<bool> RemoveProductAsync(int cartId, int productId)
    {
        var item = _dbContext.OrderProducts
            .FirstOrDefault(p => (p.OrderId == cartId && p.ProductId == productId));
        if(item is null)
        {
            return false;
        }
        _dbContext.Set<OrderProduct>().Remove(item);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}