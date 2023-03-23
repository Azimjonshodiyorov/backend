namespace NetCoreDemo.Services;

public interface IRoleService
{
    Task<string> CreateRoleAsync(string roleName);
    Task<bool> DeleteRoleAsync(string roleName);

}