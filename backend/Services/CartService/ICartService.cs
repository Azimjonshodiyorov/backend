namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;

public interface ICartService
{
    Task<int> AddProductsAsync(int id, ICollection<CartAddProductDTO> products);
}