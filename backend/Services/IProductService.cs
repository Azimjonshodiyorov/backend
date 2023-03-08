using NetCoreDemo.DTOs;
using NetCoreDemo.Models;

namespace NetCoreDemo.Services;

public interface IProductService : ICrudService<Product, ProductDTO>
{

}