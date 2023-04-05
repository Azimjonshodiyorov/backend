namespace NetCoreDemo.Controllers;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using NetCoreDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

// [Authorize(Roles = "Admin")]
public class OrderController : CrudController<Order, OrderDTO>
{
    private readonly IOrderService _orderService;
    private readonly UserManager<User> _userManager;
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

    [HttpGet("username"), Authorize(Roles = "Customer")]
    public async Task<IActionResult> GetOrderByUsername()
    {
        var userEmail =  HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sub);
        if(userEmail is null)
        {
            return Ok(userEmail);
        }

        var result = await _orderService.GetOrderByUsernameAsync(userEmail.ToString());
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