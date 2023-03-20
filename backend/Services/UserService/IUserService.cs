namespace NetCoreDemo.Services;

using NetCoreDemo.DTOs;
using NetCoreDemo.Models;

public interface IUserService
{
    Task<User?> SignUpAsync(UserSignUpDTO request);
    Task<UserSignInResponseDTO?> SignInAsync(UserSignInDTO request);
    Task<User?> FindByEmailAsync(string email);
}