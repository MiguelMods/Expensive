using Expensive.Application.Models;
using Expensive.Application.Services.Contracts;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace Expensive.Application.Services.Implementations;

public class HttpContextUserHelper(IHttpContextAccessor httpContextAccessor) : IHttpContextUserHelper
{
    public IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    public string? GetName() =>
        HttpContextAccessor.HttpContext?.User?.Claims
            .FirstOrDefault(x => x.Type == "name")?.Value ??
        HttpContextAccessor.HttpContext?.User?.Claims
            .FirstOrDefault(x => x.Type == "nickname")?.Value;

    public UserToken GetUserToken()
        => new(HttpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Name)?.Value,
               HttpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Nickname)?.Value,
               HttpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type.Contains(JwtRegisteredClaimNames.Email))?.Value,
               HttpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type.Contains("role"))?.Value);
}
