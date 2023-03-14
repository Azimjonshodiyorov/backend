namespace NetCoreDemo.Services;

using NetCoreDemo.DTOs;
using NetCoreDemo.Models;

public interface IUserService
{
    Task<User?> SignUpAsync(UserSignUpDTO request);
}