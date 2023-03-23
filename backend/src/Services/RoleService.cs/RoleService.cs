namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using Microsoft.AspNetCore.Identity;
using NetCoreDemo.Helpers;

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
            var createRole = await _roleManager.CreateAsync(new IdentityRole<int>{

                Name = roleName

            });
        }
        return roleName;
    }

    public async Task<bool> DeleteRoleAsync(string roleName)
    {
        var foundRole = await _roleManager.FindByNameAsync((string)roleName);
        if(foundRole is null)
        {
            throw ServiceException.NotFound($"{roleName} role not found");
        }
        var deleteRole = await _roleManager.DeleteAsync(foundRole);
        if(deleteRole is null)
        {
            throw ServiceException.BadRequest($"{roleName} cannot delete");
        }
        return true;
    }
}