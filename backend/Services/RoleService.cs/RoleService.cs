namespace NetCoreDemo.Services;

using NetCoreDemo.DTOs;
using NetCoreDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class RoleService : IRoleService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<int>> _roleManager;

    public RoleService(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<string> CreateRoleAsync(string roleName)
    {
        if (await _roleManager.FindByNameAsync((string)roleName) is null)
        {
            await _roleManager.CreateAsync(new IdentityRole<int>{

                Name = roleName

            });
        }
        return roleName;
    }

}