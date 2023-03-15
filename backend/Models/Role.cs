using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace NetCoreDemo.Models;

public class Role : IdentityUser<int>
{
    [MaxLength(256)]
    public string RoleName { get; set; } = null!;

  public static explicit operator Role(string v)
  {
    throw new NotImplementedException();
  }
}