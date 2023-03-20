namespace NetCoreDemo.Repositories;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;

public interface IOrderRepo : ICrudRepo<Order, OrderDTO>
{
    Task<Order> GetOrderByUsernameAsync(string userName);
    Task<int> AddProductsAsync(int id, ICollection<OrderAddProductsDTO> products);
    Task<bool> RemoveProductAsync(int orderId, int productId);
    Task<int> UpdateProductsAsync(int id, ICollection<OrderAddProductsDTO> products);

}