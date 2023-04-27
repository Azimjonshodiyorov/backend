namespace NetCoreDemo.Controllers;

using NetCoreDemo.Services;
using NetCoreDemo.Models;
using NetCoreDemo.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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

    [HttpGet("myinfo"),Authorize(Roles = "Customer")]
    public async Task<IActionResult?> FindById()
    {
        var userEmail = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Email).Value;
        var response = await _service.FindByEmailAsync(userEmail);
        return Ok(UserSignUpResponseDTO.FromUser((User)response));
    }

    [HttpPost("change-password"),Authorize(Roles = "Customer")]    
    public async Task<IActionResult> ChangePassword(string currentPassword, string newPassword)
    {
        var userEmail = HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Email).Value;
        var response = await _service.ChangePasswordAsync(userEmail, currentPassword, newPassword);
        return Ok(response);
    }

    [HttpDelete("delete-byadmin/{userEmail}"),Authorize(Roles = "Admin")]    
    public async Task<IActionResult> DeleteUser(string userEmail)
    {
        var response = await _service.DeleteAsync(userEmail);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet("role/{userId}")]    
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