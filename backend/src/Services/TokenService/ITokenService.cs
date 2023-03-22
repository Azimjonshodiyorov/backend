namespace NetCoreDemo.Services;

using NetCoreDemo.Models;
using NetCoreDemo.DTOs;

public interface ITokenService
{
    Task<UserSignInResponseDTO> GenerateTokenAsync(User user);
}