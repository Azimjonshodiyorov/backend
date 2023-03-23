namespace NetCoreDemo.Controllers;

using NetCoreDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Admin")]
public class RoleController : ApiControllerBase
{
    private readonly IRoleService _service;

    public RoleController(IRoleService service) 
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody]string roleName)
    {
        var role = await _service.CreateRoleAsync(roleName);
        return Ok(role);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteRole([FromBody]string roleName)
    {
        return Ok(await _service.DeleteRoleAsync(roleName));
    }

}