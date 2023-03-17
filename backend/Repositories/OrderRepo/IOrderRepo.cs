namespace NetCoreDemo.Repositories;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;

public interface IOrderRepo : ICrudRepo<Order, OrderDTO>
{
    Task<int> AddProductsAsync(int id, ICollection<OrderAddProductsDTO> products);
    Task<bool> RemoveProductAsync(int orderId, int productId);
}