namespace NetCoreDemo.Services;

using NetCoreDemo.DTOs;
using NetCoreDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager) 
    {
         _userManager = userManager;
    }

    public async Task<User?> SignUpAsync(UserSignUpDTO request)
    {
        Console.WriteLine($"The request in UserService first is {request.FirstName}, {request.LastName}, {request.Email}, {request.Password}");

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.Email,
            Email = request.Email,
        };
        var result = await _userManager.CreateAsync(user, request.Password);
        Console.WriteLine($"After CreateAsync {result}");

        if (!result.Succeeded)
        {
            return user;
        }
        return user;
    }
}