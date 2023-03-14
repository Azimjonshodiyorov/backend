namespace NetCoreDemo.Repositories;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;

public interface IProductRepo : ICrudRepo<Product, ProductDTO>
{

}