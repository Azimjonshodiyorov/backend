namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;

public interface IOrderService : ICrudService<Order, OrderDTO>
{
    Task<int> AddProductsAsync(int id, ICollection<OrderAddProductsDTO> products);
    Task<bool> RemoveProductAsync(int orderId, int productId);
}