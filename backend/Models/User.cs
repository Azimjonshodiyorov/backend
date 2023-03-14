using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace NetCoreDemo.Models;

public class User : IdentityUser<int>
{
    [MaxLength(256)]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(256)]
    public string LastName { get; set; } = null!;

}
// public class User : IdentityUser<int>
//     {
//         public string UserName { get; set; }
//         [EmailAddressAttribute]
//         public string Email { get; set; }
//         public Role Role { get; set; }
//         public byte[] Password { get; set; }
//         public byte[] Salt { get; set; }
//     }

//     public enum Role {
//         Admin,
//         Customer
//     }