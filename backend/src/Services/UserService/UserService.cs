namespace NetCoreDemo.Services;

using NetCoreDemo.DTOs;
using NetCoreDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetCoreDemo.Helpers;
using System.Runtime.CompilerServices;

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
            throw ServiceException.BadRequest("User cannot create");
        }

        var userRole = "Customer";
        string[] rolesarray = new string[400];

        var roles = await _roleservice.CreateRoleAsync(userRole);
        if(roles is null)
        {
            throw ServiceException.BadRequest("Role cannot create");
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
            throw ServiceException.Unauthorized("Not valid user");
        }
        if(!await _userManager.CheckPasswordAsync(user,request.Password))
        {
            throw ServiceException.Unauthorized("Wrong Password");
        }
        return await _tokenService.GenerateTokenAsync(user);
    }

    public async Task<User?> FindByEmailAsync(string userEmail)
    {
        var user = await _userManager.FindByEmailAsync(userEmail);
        if(user is null)
        {
            throw ServiceException.NotFound("Something went wrong!");
        }
        return user;
    }

    public async Task<IdentityResult> ChangePasswordAsync(string email, string currentPassword, string newPassword)
    {
        var user = await FindByEmailAsync(email);
        if(user is null)
        {
            throw ServiceException.NotFound("User not found");
        }
        if(!await _userManager.CheckPasswordAsync(user,currentPassword ))
        {
            throw ServiceException.Unauthorized("Wrong Password");
        }
        
        var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        return result; 
    }

    public async Task<bool> DeleteAsync(string userEmail)
    {
        var foundUser = await FindByEmailAsync(userEmail);
        if(foundUser is null)
        {
            throw ServiceException.Unauthorized("Wrong Email, User not found!");
        }
        var deleteUser = await _userManager.DeleteAsync(foundUser);
        if(deleteUser is null)
        {
            return false;
        }
        return true;
    }

    public async Task<ICollection<string>> GetRolesAsync(string userId)
    {
        var foundUser = await _userManager.FindByIdAsync(userId);
        if(foundUser is null)
        {
            throw ServiceException.NotFound("User not found");
        }
        var findRole = await _userManager.GetRolesAsync(foundUser);
        if(findRole is null)
        {
            throw ServiceException.NotFound($"No role for {foundUser.FirstName}");
        }
        return findRole;
    }

    public async Task<ICollection<User>> GetAllAsync()
    {
        var result = _userManager.Users.Include(u => u.Orders).ToList();
        if(result is null)
        {
            throw ServiceException.NotFound("Due to some error, cannot retrieve users");
        }
        return result;
    }
}