using Expensive.Application.Services.Contracts;

namespace Expensive.Application.Services.Implementations;

public class JwtTokenService : IJwtTokenService
{
    public Task<string> GenerateRefreshTokenAsync(string userName, string email, string role, string? userId = null)
    {
        throw new NotImplementedException();
    }

    public Task<string> GenerateTokenAsync(string userName, string email, string role, string? userId = null)
    {
        throw new NotImplementedException();
    }
}
