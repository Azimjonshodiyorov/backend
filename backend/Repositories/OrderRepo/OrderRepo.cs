namespace NetCoreDemo.Repositories;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Db;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

public class OrderRepo : CrudRepo<Order, OrderDTO>, IOrderRepo
{
    // private readonly AppDbContext _dbContext;
    public OrderRepo(AppDbContext dbContext) : base(dbContext)
    {
        // _dbContext = dbContext;
    }

    public async Task<Order> GetOrderByUsernameAsync(string userName)
    {
        var query = _dbContext.Orders.FirstOrDefault(p => p.OrderName == userName);
        return query;
    }

    [AllowAnonymous]
    public override async Task<Order?> CreateAsync(OrderDTO request)
    {
        var item = new Order();
        request.UpdateModel(item);
        _dbContext.Add(item);
        await _dbContext.SaveChangesAsync(); 
        return item;
    }

    public override async Task<Order?> GetAsync(int id)
    {
        return await _dbContext.Orders
            .Include(p => p.ProductLinks)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<int> AddProductsAsync(int id, ICollection<OrderAddProductsDTO> request)
    {
        var order = await GetAsync(id);

        if (order is null)
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
                order.ProductLinks.Add(new OrderProduct
                {
                    Order = order,
                    Quantity = item.Quantity,
                    ProductId = item.ProductId,
                });
            }

        await _dbContext.SaveChangesAsync();
        return products.Count();
    }


    public async Task<bool> RemoveProductAsync(int orderId, int productId)
    {
        var item = _dbContext.OrderProducts
            .FirstOrDefault(p => (p.OrderId == orderId && p.ProductId == productId));
        if(item is null)
        {
            return false;
        }
        _dbContext.Set<OrderProduct>().Remove(item);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveAllProductAsync(int orderId)
    {
        var item = _dbContext.OrderProducts
            .FirstOrDefault(p => (p.OrderId == orderId));
        if(item is null)
        {
            return false;
        }
        _dbContext.Set<OrderProduct>().Remove(item);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<int> UpdateProductsAsync(int id, ICollection<OrderAddProductsDTO> products)
    {
        var item = await GetAsync(id);
        if(item is null)
        {
            return -1;
        }
        var removeOldProducts = await RemoveAllProductAsync(id);
        if(!removeOldProducts)
        {
            return -1;
        }
        var updatedResult =  await AddProductsAsync(id, products);
        return updatedResult;
    }
}