using System.ComponentModel.DataAnnotations;

namespace NetCoreDemo.DTOs;

public class UserSignInDTO
{
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
}