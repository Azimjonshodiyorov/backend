namespace NetCoreDemo.Services;

using NetCoreDemo.DTOs;
using NetCoreDemo.Models;

public interface IRoleService
{
    Task<string> CreateRoleAsync(string roleName);
    Task<bool> DeleteRoleAsync(string roleName);

}