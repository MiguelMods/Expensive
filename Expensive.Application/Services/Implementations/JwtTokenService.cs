using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Expensive.Application.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Expensive.Application.Services.Implementations;

public class JwtTokenService(IConfiguration configuration) : IJwtTokenService
{
    public Task<string> GenerateTokenAsync(string userName, string email, string role, string? userId = null)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Name, userName),
            new Claim(JwtRegisteredClaimNames.Nickname, userName),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim("role", role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(configuration["Jwt:ExpiresInMinutes"])),
            signingCredentials: creds
        );

        var stringToken = new JwtSecurityTokenHandler().WriteToken(token);

        return Task.FromResult(stringToken);
    }

    public Task<string> GenerateRefreshTokenAsync(string userName, string email, string role, string? userId = null)
    {
        throw new NotImplementedException();
    }
}
