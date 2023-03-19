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

    [HttpGet("username")]
    public async Task<IActionResult> GetOrderByUsername(string userName)
    {
        var result = await _orderService.GetOrderByUsernameAsync(userName);
        if (result is null)
        {
            return BadRequest("Please Login!");
        }
        return Ok(result);
    }

    [HttpPost("{id}/add-products")]
    public async Task<IActionResult> AddProducts(int id, ICollection<OrderAddProductsDTO> request)
    {
        var added = await _orderService.AddProductsAsync(id, request);
        if (added <= 0)
        {
            return BadRequest("Please Login!");
        }
        return Ok("Product added to your order");
    }

    [HttpDelete("{id}/delete-product")]
    public async Task<IActionResult> DeleteProductAsync(int id, int productId)
    {
        var added = await _orderService.RemoveProductAsync(id, productId);
        if (!added)
        {
            return BadRequest("Failed to delete");
        }

      return Ok("Product deleted from your order");
    }

    [HttpDelete("{id}/delete-allproduct")]
    public async Task<IActionResult> DeleteAllProductAsync(int id)
    {
        var added = await _orderService.RemoveAllProductAsync(id);
        if (!added)
        {
            return BadRequest("Failed to delete");
        }

      return Ok("Products deleted from your order");
    }

    [HttpPut("{id}/update-product")]
    public async Task<IActionResult> UpdateProducts(int id, ICollection<OrderAddProductsDTO> request)
    {
        var updated = await _orderService.UpdateProductsAsync(id, request);
        if (updated <= 0)
        {
            return BadRequest("Failed to update products");
        }
        return Ok("Product updated");
    }
}