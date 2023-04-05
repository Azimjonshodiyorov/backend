namespace NetCoreDemo.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using NetCoreDemo.Db;
using NetCoreDemo.DTOs;
using NetCoreDemo.Helpers;
using NetCoreDemo.Models;
using NetCoreDemo.Repositories;

public class OrderService : CrudService<Order, OrderDTO>, IOrderService
{

    protected readonly IOrderRepo _repo;
    public OrderService(AppDbContext dbContext, IOrderRepo repo) : base(dbContext, repo)
    {
        _repo = repo;
    }

    public async Task<Order> GetOrderByUsernameAsync(string userEmail)
    {
        var result =  await _repo.GetOrderByUsernameAsync(userEmail);
                Console.WriteLine($"=================in service {userEmail}========");

        if(result is null)
        {
            throw ServiceException.NotFound("Order not found");
        }
        return result;
    }

    public override async Task<Order?> GetByIdAsync(int id)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity is null)
        {
            throw ServiceException.BadRequest("No order in this id");
        }
        return entity;
    }

    public async Task<int> AddProductsAsync(int id, ICollection<OrderAddProductsDTO> request)
    {
        
        var entity = await _repo.AddProductsAsync(id, request);
        if (entity <= 0)
        {
            throw ServiceException.BadRequest("Products cannot add");
        }
        return entity;
    }


    public async Task<bool> RemoveProductAsync(int orderId, int productId)
    {
        var entity = await _repo.RemoveProductAsync(orderId, productId);
        if (entity is false)
        {
            throw ServiceException.BadRequest("Product cannot deleted");
        }
        return true;
    }

    public async Task<int> UpdateProductsAsync(int id, ICollection<OrderAddProductsDTO> request)
    {
        var entity = await _repo.UpdateProductsAsync(id, request);
        if (entity <= 0)
        {
            throw ServiceException.BadRequest("Products cannot update");
        }
        return entity;
    }
}