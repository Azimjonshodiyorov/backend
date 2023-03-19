namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;

public interface IOrderService : ICrudService<Order, OrderDTO>
{
    Task<Order> GetOrderByUsernameAsync(string userName);
    Task<int> AddProductsAsync(int id, ICollection<OrderAddProductsDTO> products);
    Task<bool> RemoveProductAsync(int orderId, int productId);
    Task<bool> RemoveAllProductAsync(int orderId);
    Task<int> UpdateProductsAsync(int id, ICollection<OrderAddProductsDTO> products);
}