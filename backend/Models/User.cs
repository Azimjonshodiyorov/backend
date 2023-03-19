using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace NetCoreDemo.Models;

public class User : IdentityUser<int>
{

  [MaxLength(256)]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(256)]
    public string LastName { get; set; } = null!;
    public ICollection<Order> Orders { get; set; } = null!;
}