namespace NetCoreDemo.Controllers;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

public class OrderController : CrudController<Order, OrderDTO>
{
    private readonly IOrderService _orderService;
    private readonly UserManager<User> _userManager;
    public OrderController(IOrderService service) : base(service)
    {
          _orderService = service;
    }

    [HttpGet,Authorize(Roles = "Admin")]
    public override async Task<ActionResult<IEnumerable<Order>>> GetAll(int page, int itemsperpage)
    {
        return Ok(await _service.GetAllAsync(page, itemsperpage));
    }

    [HttpPost,Authorize(Roles = "Customer")]
    public override async Task<IActionResult> Create(OrderDTO request)
    {
        var item = await _service.CreateAsync(request);
        return Ok(item);
    }   

    [HttpGet("my-orders"),Authorize(Roles = "Customer")]
    public async Task<IActionResult> GetOrderByUsername()
    {
        var userEmail = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Email).Value;
        var result = await _orderService.GetOrderByUsernameAsync(userEmail);
        return Ok(result);
    }

    [HttpPost("{id}/add-products"),Authorize(Roles = "Customer")]
    public async Task<IActionResult> AddProducts(int id, ICollection<OrderAddProductsDTO> request)
    {
        return Ok(await _orderService.AddProductsAsync(id, request));
    }

    [HttpDelete("{id}/remove-product"),Authorize(Roles = "Customer")]
    public async Task<IActionResult> DeleteProductAsync(int id, int productId)
    {
        return Ok(await _orderService.RemoveProductAsync(id, productId));
    }

    [HttpPut("{id}/update-product"),Authorize(Roles = "Customer")]
    public async Task<IActionResult> UpdateProducts(int id, ICollection<OrderAddProductsDTO> request)
    {
        return Ok(await _orderService.UpdateProductsAsync(id, request));
    }
}