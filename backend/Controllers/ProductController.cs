namespace NetCoreDemo.Controllers;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Services;

public class ProductController : CrudController<Product, ProductDTO>
{
  public ProductController(ICrudService<Product, ProductDTO> service) : base(service)
  {
  }
}