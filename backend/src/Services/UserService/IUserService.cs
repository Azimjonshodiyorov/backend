namespace NetCoreDemo.Services;

using Microsoft.AspNetCore.Identity;
using NetCoreDemo.DTOs;
using NetCoreDemo.Models;

public interface IUserService
{
    Task<User?> SignUpAsync(UserSignUpDTO request);
    Task<UserSignInResponseDTO?> SignInAsync(UserSignInDTO request);
    Task<User?> FindByEmailAsync(string userEmail);
    Task<IdentityResult> ChangePasswordAsync(string email, string currentPassword, string newPassword);
    Task<bool> DeleteAsync(string userEmail);
    Task<ICollection<string>> GetRolesAsync(string userId);
    Task<ICollection<User>> GetAllAsync();
}