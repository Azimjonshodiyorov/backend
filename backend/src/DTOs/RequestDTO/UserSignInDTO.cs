using System.ComponentModel.DataAnnotations;

namespace NetCoreDemo.DTOs;

public class UserSignInDTO
{
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}