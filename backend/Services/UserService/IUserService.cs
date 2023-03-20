namespace NetCoreDemo.Services;

using NetCoreDemo.DTOs;
using NetCoreDemo.Models;

public interface IUserService
{
    Task<User?> SignUpAsync(UserSignUpDTO request);
    Task<UserSignInResponseDTO?> SignInAsync(UserSignInDTO request);
    Task<User?> FindByIdAsync(string userId);
    Task<User?> FindByEmailAsync(string email);
    Task<User> ChangePasswordAsync(string email, string currentPassword, string newPassword);
    Task<bool> DeleteAsync(string userId);
    Task<ICollection<string>> GetRolesAsync(string userId);
}