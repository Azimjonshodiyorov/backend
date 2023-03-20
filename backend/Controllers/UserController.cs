namespace NetCoreDemo.Controllers;

using NetCoreDemo.Services;
using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;

[Authorize]
public class UserController : ApiControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service) 
    {
        _service = service;
    }

    [AllowAnonymous]
    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(UserSignUpDTO request)
    {
        var user = await _service.SignUpAsync(request);
        if (user is null)
        {
            return BadRequest();
        }
        return Ok(UserSignUpResponseDTO.FromUser((User)user));
    }

    [AllowAnonymous]
    [HttpPost("signin")]    
    public async Task<IActionResult> SignIn(UserSignInDTO request)
    {
        var response = await _service.SignInAsync(request);
        if (response is null)
        {
            return Unauthorized();
        }
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet("{userId}")]
    public async Task<IActionResult?> FindById(string userId)
    {
        var response = await _service.FindByIdAsync(userId);
        if(response is null)
        {
            return BadRequest("No Valid User");
        }
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet("email")]
    public async Task<IActionResult?> FindByEmail(string email)
    {
        Console.WriteLine($"==========={email} =========");

        var response = await _service.FindByEmailAsync(email);
        if(response is null)
        {
            return BadRequest("No Valid User");
        }
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("change-password")]    
    public async Task<IActionResult> ChangePassword(string email, string currentPassword, string newPassword)
    {
        var response = await _service.ChangePasswordAsync(email, currentPassword, newPassword);
        if (response is null)
        {
            return BadRequest("Password update failed");
        }
        return Ok(response);
    }
}