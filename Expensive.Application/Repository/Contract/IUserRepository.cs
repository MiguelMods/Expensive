using Expensive.Domain.Entities;

namespace Expensive.Application.Repository.Contract;

public interface IUsersRepository : IGenericRepository<Users>
{
    Task<Users?> GetByUserNameAndPassword(string userName);
    Task<Users?> GetByEmailAsync(string email);
    Task<Users?> GetByUserNameAsync(string userName);
    Task<bool> UpdateUserPassword(string userName, string password, string updateBy);
    Task<bool> UpdateOldPasswordToPassword(string userName, string oldPassword, string newPassword, string updateBy);
}
