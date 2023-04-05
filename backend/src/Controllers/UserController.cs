namespace NetCoreDemo.Controllers;

using NetCoreDemo.Services;
using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

[Authorize(Roles = "Admin")]
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
        return Ok(UserSignUpResponseDTO.FromUser((User)user));
    }

    [AllowAnonymous]
    [HttpPost("signin")]    
    public async Task<IActionResult> SignIn(UserSignInDTO request)
    {
        var response = await _service.SignInAsync(request);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet("{userId}")]
    public async Task<IActionResult?> FindById(string userId)
    {
        var response = await _service.FindByIdAsync(userId);
        return Ok(UserSignUpResponseDTO.FromUser((User)response));
    }

    [AllowAnonymous]
    [HttpGet("email")]
    public async Task<IActionResult?> FindByEmail(string email)
    {
        var response = await _service.FindByEmailAsync(email);
        return Ok(UserSignUpResponseDTO.FromUser((User)response));
    }

    [AllowAnonymous]
    [HttpPost("change-password")]    
    public async Task<IActionResult> ChangePassword(string email, string currentPassword, string newPassword)
    {
        var response = await _service.ChangePasswordAsync(email, currentPassword, newPassword);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpDelete("delete/{userId}")]    
    public async Task<IActionResult> DeleteUser(string userId)
    {
        var response = await _service.DeleteAsync(userId);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet("role")]    
    public async Task<IActionResult> GetRole(string userId)
    {
        var response = await _service.GetRolesAsync(userId);
        return Ok(response);
    }

    [HttpGet("all")]    
    public async Task<IActionResult> GetAll()
    {
        var response = await _service.GetAllAsync();
        return Ok(response);
    }
}