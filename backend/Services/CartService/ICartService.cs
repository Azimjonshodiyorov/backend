namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;

public interface ICartService : ICrudService<Cart, CartDTO>
{
    Task<int> AddProductsAsync(int id, ICollection<CartAddProductsDTO> products);
}