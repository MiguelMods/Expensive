namespace Expensive.Application.Services.Contracts;

public interface IHashPassordService
{
    Task<string> HashPassword(string password);
    Task<bool> VerifyPassword(string hashedPassword, string providedPassword);
}
