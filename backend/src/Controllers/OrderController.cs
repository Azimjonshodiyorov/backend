namespace NetCoreDemo.Controllers;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Admin")]
public class OrderController : CrudController<Order, OrderDTO>
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService service) : base(service)
    {
          _orderService = service;
    }

    [HttpGet]
    public override async Task<ActionResult<IEnumerable<Order>>> GetAll(int page, int itemsperpage)
    {
        return Ok(await _service.GetAllAsync(page, itemsperpage));
    }

    [AllowAnonymous]
    [HttpPost]
    public override async Task<IActionResult> Create(OrderDTO request)
    {
        var item = await _service.CreateAsync(request);
        return Ok(item);
    }

    [AllowAnonymous]
    [HttpGet("username")]
    public async Task<IActionResult> GetOrderByUsername(string userName)
    {
        var result = await _orderService.GetOrderByUsernameAsync(userName);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("{id}/add-products")]
    public async Task<IActionResult> AddProducts(int id, ICollection<OrderAddProductsDTO> request)
    {
        return Ok(await _orderService.AddProductsAsync(id, request));
    }

    [AllowAnonymous]
    [HttpDelete("{id}/remove-product")]
    public async Task<IActionResult> DeleteProductAsync(int id, int productId)
    {
        return Ok(await _orderService.RemoveProductAsync(id, productId));
    }

    [AllowAnonymous]
    [HttpPut("{id}/update-product")]
    public async Task<IActionResult> UpdateProducts(int id, ICollection<OrderAddProductsDTO> request)
    {
        return Ok(await _orderService.UpdateProductsAsync(id, request));
    }
}