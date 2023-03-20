namespace NetCoreDemo.Services;

using NetCoreDemo.DTOs;
using NetCoreDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IRoleService _roleservice;
    private readonly ITokenService _tokenService;
    private readonly IOrderService _orderService;
    protected ILookupNormalizer normalizer;

    public UserService(UserManager<User> userManager, IRoleService roleservice, ITokenService tokenService, IOrderService orderService) 
    {
        _userManager = userManager;
        _roleservice = roleservice;
        _tokenService = tokenService;
        _orderService = orderService;
    }

   public async Task<User?> SignUpAsync(UserSignUpDTO request)
    {
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.Email,
            Email = request.Email,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            return null;
        }

        var userRole = "Customer";
        string[] rolesarray = new string[400];

        var roles = await _roleservice.CreateRoleAsync(userRole);
        if(roles is null)
        {
            throw new Exception("Role cannot created");
        }
        for (int i = 0; i < 400; i++)
        {
            rolesarray[i] = roles;
        }
        rolesarray.Concat(new string[] { roles });

        await _userManager.AddToRolesAsync(user, rolesarray);
        return user;
    }
    
    public async Task<UserSignInResponseDTO?> SignInAsync(UserSignInDTO request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if(user is null)
        {
            return null;
        }
        if(!await _userManager.CheckPasswordAsync(user,request.Password ))
        {
            return null;
        }
        return await _tokenService.GenerateTokenAsync(user);
    }


    public async Task<User?> FindByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if(user is null)
        {
            return null;
        }
        return user;
    }
}