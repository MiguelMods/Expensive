using BCrypt.Net;
using Expensive.Application.Services.Contracts;

namespace Expensive.Application.Services.Implementations;

public class HashPassordService : IHashPassordService
{
    private readonly int WorkFactor = 10;
    public Task<string> HashPassword(string password)
        => Task.FromResult(BCrypt.Net.BCrypt.HashPassword(password, WorkFactor));

    public Task<bool> VerifyPassword(string hashedPassword, string providedPassword)
        => Task.FromResult(BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword));
}
