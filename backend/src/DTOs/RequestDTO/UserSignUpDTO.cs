using System.ComponentModel.DataAnnotations;

namespace NetCoreDemo.DTOs;

public class UserSignUpDTO
{
    [Required]
    [MaxLength(25, ErrorMessage = "Name exceeds letters")]
    [MinLength(3, ErrorMessage = "Name requires atleast 3 letter")]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(25, ErrorMessage = "Name exceeds letters")]
    [MinLength(3, ErrorMessage = "Name requires atleast 3 letter")]
    public string LastName { get; set; } = null!;

    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}
