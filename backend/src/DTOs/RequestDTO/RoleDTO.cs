using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace NetCoreDemo.Models;

public class RoleDTO 
{
    [StringLength(15, MinimumLength = 1)]
    public string RoleName { get; set; } = null!;

    public static implicit operator string(RoleDTO v)
    {
      throw new NotImplementedException();
    }
}