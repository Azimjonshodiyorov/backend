namespace NetCoreDemo.Controllers;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Services;
using Microsoft.AspNetCore.Mvc;
using NetCoreDemo.Common;

public class ProductController : CrudController<Product, ProductDTO>
{ 
    private readonly IProductService _productService;

  public ProductController(IProductService service) : base(service)
    {
       _productService = service;
    }

  [HttpGet]
  public override async Task<ICollection<Product>> GetAll()
  {
      var @params = Request.QueryString.ParseParams<PaginationParams>();
      return await _productService.GetAllAsync(@params);
  }

  [HttpGet("filter")]
  public async Task<ICollection<Product>> GetByName()
  {
      var filter = Request.QueryString.ParseParams<ProductFilterDTO>();
      return await _productService.GetByNameAsync(filter);
  }
}