using Expensive.Application.Services.Contracts;
using Microsoft.AspNetCore.Http;

namespace Expensive.Application.Services.Implementations;

public class HttpContextUserHelper(IHttpContextAccessor httpContextAccessor) : IHttpContextUserHelper
{
    public IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
    public string? GetName() =>
        HttpContextAccessor.HttpContext?.User?.Claims
            .FirstOrDefault(x => x.Type == "name")?.Value ??
        HttpContextAccessor.HttpContext?.User?.Claims
            .FirstOrDefault(x => x.Type == "nickname")?.Value;
}
