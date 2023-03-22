namespace NetCoreDemo.Controllers;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;

// [Authorize(Roles = "Admin")]
public class ProductController : CrudController<Product, ProductDTO>
{
    private readonly IProductService _productService;

    public ProductController(IProductService service) : base(service)
    {
        _productService = service;
    }

    [AllowAnonymous]
    [HttpGet("filter")]
    public async Task<ActionResult<IEnumerable<Product>>> GetByFiltering(string? name, string? keyword, double? price, double? price_max, double? price_min, int? categoryId)
    {
        if (name is not null || keyword is not null)
        {
          return Ok(await _productService.GetByNameAsync(name, keyword));
        }

        if (price is not null)
        {
          return Ok(await _productService.GetByPriceAsync((double)price));
        }

        if (price_max is not null && price_min is not null )
        {
          return Ok(await _productService.GetByPriceRangeAsync((double)price_min, (double)price_max));
        }
        if(categoryId is not null)
        {
            return Ok(await _productService.GetProductsByCategoryAsync((int)categoryId));
        }
        return Ok(await base.GetAll(1,10));
    }
}