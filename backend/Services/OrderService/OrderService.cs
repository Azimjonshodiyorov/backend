namespace NetCoreDemo.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreDemo.Db;
using NetCoreDemo.DTOs;
using NetCoreDemo.Models;
using NetCoreDemo.Repositories;

public class OrderService : CrudService<Order, OrderDTO>, IOrderService
{

    protected readonly IOrderRepo _repo;
    public OrderService(AppDbContext dbContext, IOrderRepo repo) : base(dbContext, repo)
    {
        _repo = repo;
    }


    public override async Task<Order?> GetAsync(int id)
    {
        var entity = await _repo.GetAsync(id);
        if (entity is null)
        {
            throw new Exception("Due to some error, your cart not found");
        }
        return entity;
    }



    public async Task<int> AddProductsAsync(int id, ICollection<OrderAddProductsDTO> request)
    {
        var entity = await _repo.AddProductsAsync(id, request);
        if (entity is 0)
        {
            throw new Exception("Products cannot add");
        }
        return entity;
    }


    public async Task<bool> RemoveProductAsync(int cartId, int productId)
    {
        var entity = await _repo.RemoveProductAsync(cartId, productId);
        if (false)
        {
            throw new Exception("Products cannot deleted");
        }
        return true;

    }
}