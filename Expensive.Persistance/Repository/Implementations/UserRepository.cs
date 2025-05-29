using Expensive.Application.Repository.Contract;
using Expensive.Domain.Entities;
using Expensive.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Expensive.Persistance.Repository.Implementations;

public class UserRepository(ExpensiveApplicationDataContext expensiveApplicationDataContext) : GenericRepository<Users>(expensiveApplicationDataContext), IUsersRepository
{
    public async Task<Users?> GetByUserNameAndPassword(string userName, string password)
        => await ExpensiveApplicationDataContext.Users
            .FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password && u.IsDeleted != true);

    public async Task<Users?> GetByEmailAsync(string email)
        => await ExpensiveApplicationDataContext.Users
            .FirstOrDefaultAsync(u => u.Email == email && u.IsDeleted != true);

    public async Task<Users?> GetByUserNameAsync(string userName)
        => await ExpensiveApplicationDataContext.Users
            .FirstOrDefaultAsync(u => u.UserName == userName && u.IsDeleted != true);

    public async Task<bool> UpdateOldPasswordToPassword(string userName, string oldPassword, string newPassword) 
    {
        var user = await ExpensiveApplicationDataContext.Users
            .FirstOrDefaultAsync(u => u.UserName == userName && u.Password == oldPassword && u.IsDeleted != true) 
            ?? throw new Exception("User not Found");
        
        user.Password = newPassword;
        user.UpdatedBy = "System";
        user.UpdatedAt = DateTime.UtcNow;
        
        return true;
    }

    public async Task<bool> UpdateUserPassword(string userName, string password) 
    {
        var user =  await ExpensiveApplicationDataContext.Users
            .FirstOrDefaultAsync(u => u.UserName == userName && u.IsDeleted != true) ?? throw new Exception("User not Found");

        user.Password = password;
        user.UpdatedBy = "System";
        user.UpdatedAt = DateTime.UtcNow;

        return true;
    } 
}
