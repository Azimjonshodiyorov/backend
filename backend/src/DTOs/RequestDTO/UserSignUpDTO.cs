using System.ComponentModel.DataAnnotations;

namespace NetCoreDemo.DTOs;

public class UserSignUpDTO
{
    [Required]
    [MaxLength(25, ErrorMessage = "Name exceeds characters")]
    [MinLength(3, ErrorMessage = "Name requires atleast 3 characters")]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(25, ErrorMessage = "Name exceeds characters")]
    [MinLength(3, ErrorMessage = "Name requires atleast 3 characters")]
    public string LastName { get; set; } = null!;

    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [MaxLength(20, ErrorMessage = "Password exceeds characters")]
    [MinLength(6, ErrorMessage = "Password requires atleast 6 characters")]
    public string Password { get; set; } = null!;
}
