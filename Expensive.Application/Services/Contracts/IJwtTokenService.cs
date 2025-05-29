namespace Expensive.Application.Services.Contracts;

public interface IJwtTokenService
{
    Task<string> GenerateTokenAsync(string userName, string email, string role, string? userId = null);
    Task<string> GenerateRefreshTokenAsync(string userName, string email, string role, string? userId = null);
}
