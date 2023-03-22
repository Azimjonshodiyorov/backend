namespace NetCoreDemo.DTOs;

using System;
using NetCoreDemo.Models;
public class UserSignUpResponseDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public static UserSignUpResponseDTO FromUser(User user)
    {
        return new UserSignUpResponseDTO
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName  = user.LastName,
            UserName = user.UserName,
            Email = user.Email
        };
    }
}