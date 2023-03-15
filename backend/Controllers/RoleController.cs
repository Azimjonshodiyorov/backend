namespace NetCoreDemo.Controllers;

using NetCoreDemo.Services;
using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Identity;
using System.Linq;

public class RoleController : ApiControllerBase
{
    private readonly IRoleService _service;

    public RoleController(IRoleService service) 
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole(string roleName)
    {
        Console.WriteLine($"------------The role name is {roleName}------------");
        var role = await _service.CreateRoleAsync(roleName);
        if(role is null)
        {
            return BadRequest();
        }
        return Ok();
    }

}