using Expensive.Domain.Entities;

namespace Expensive.Application.Services.Contracts;

public interface IUsersService : IService<Users>
{
    Task<Users?> RegisterAsync(Users users);
    Task<Users?> GetByUserNameAndPassword(string userName, string password);
    Task<Users?> GetByEmailAsync(string email);
    Task<Users?> GetByUserNameAsync(string userName);
    Task<bool> UpdateUserPassword(string userName, string password);
    Task<bool> UpdateOldPasswordToPassword(string userName, string oldPassword, string newPassword);
}
