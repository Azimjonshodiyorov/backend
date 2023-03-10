namespace NetCoreDemo.Controllers;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Services;
using Microsoft.AspNetCore.Mvc;
using NetCoreDemo.Common;
using System.Globalization;

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
  public async Task<ICollection<Product>> GetByFiltering(string? name, string? keyword, double? price, double? price_max, double? price_min)
  {
      if (name is not null || keyword is not null)
      {
        return await _productService.GetByNameAsync(name, keyword);
      }

      if (price is not null)
      {
        return await _productService.GetByPriceAsync((double)price);
      }

      if (price_max is not null && price_min is not null )
      {
        return await _productService.GetByPriceRangeAsync((double)price_min, (double)price_max);
      }
      return await base.GetAll();
    }
}