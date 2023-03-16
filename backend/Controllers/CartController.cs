namespace NetCoreDemo.Controllers;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Services;
using Microsoft.AspNetCore.Mvc;
using NetCoreDemo.Common;

public class CartController : CrudController<Cart, CartDTO>
{
  private readonly ICartService _cartService;
  public CartController(ICartService service) : base(service)
  {
        _cartService = service;
  }

    [HttpPost("{id}/add-products")]
    public async Task<object> AddProducts(int id, ICollection<CartAddProductsDTO> request)
    {
        return await _cartService.AddProductsAsync(id, request);
        // if (added <= 0)
        // {
        //     // return BadRequest("Invalid Product");
        //     return null;
        // }
        // return null;
        // return null;
    }
}