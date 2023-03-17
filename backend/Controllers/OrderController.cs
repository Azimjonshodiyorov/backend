namespace NetCoreDemo.Controllers;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Services;
using Microsoft.AspNetCore.Mvc;
using NetCoreDemo.Common;

public class OrderController : CrudController<Order, OrderDTO>
{
  private readonly IOrderService _orderService;
  public OrderController(IOrderService service) : base(service)
  {
        _orderService = service;
  }

    [HttpPost("{id}/add-products")]
    public async Task<IActionResult> AddProducts(int id, ICollection<OrderAddProductsDTO> request)
    {
        var added = await _orderService.AddProductsAsync(id, request);
        if (added <= 0)
        {
            return BadRequest("Please Login!");
        }
        return Ok("Product added to your cart");
    }

    [HttpDelete("{id}/delete-product")]
    public async Task<IActionResult> DeleteProductAsync(int id, int productId)
    {
        var added = await _orderService.RemoveProductAsync(id, productId);
        if (!added)
        {
            return BadRequest("Failed to delete");
        }

      return Ok("Product deleted from your cart");
    }
}