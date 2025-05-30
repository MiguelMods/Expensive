namespace Expensive.Application.Services.Contracts;

public interface IJwtTokenService
{
    Task<string> GenerateTokenAsync(string name, string userName, string email, string role);
    Task<string> GenerateRefreshTokenAsync(string name, string userName, string email, string role);
}
