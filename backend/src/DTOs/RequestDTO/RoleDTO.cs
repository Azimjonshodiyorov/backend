using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace NetCoreDemo.Models;

public class RoleDTO 
{
    [MaxLength(256)]
    public string RoleName { get; set; } = null!;

  public static implicit operator string(RoleDTO v)
  {
    throw new NotImplementedException();
  }
}