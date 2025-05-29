using Expensive.Application.Repository.Contract;
using Expensive.Application.Services.Contracts;
using Expensive.Domain.Entities;

namespace Expensive.Application.Services.Implementations;

public class UsersService(IUnitOfWork unitOfWork) : Service<Users>(unitOfWork), IUsersService
{
    IUsersRepository UsersRepository => unitOfWork.Users;

    public Task<Users?> GetByEmailAsync(string email)
        => UsersRepository.GetByEmailAsync(email);

    public Task<Users?> GetByUserNameAndPassword(string userName, string password)
        => UsersRepository.GetByUserNameAndPassword(userName, password);

    public Task<Users?> GetByUserNameAsync(string userName)
        => UsersRepository.GetByUserNameAsync(userName);

    public async Task<bool> UpdateOldPasswordToPassword(string userName, string oldPassword, string newPassword) 
    {
        await UsersRepository.UpdateOldPasswordToPassword(userName, oldPassword, newPassword);

        if (await unitOfWork.SaveChangesAsync() <= 0)
            throw new InvalidOperationException("Failed to update password in the database.");

        return true;
    }
         

    public async Task<bool> UpdateUserPassword(string userName, string password) 
    {
        await UsersRepository.UpdateUserPassword(userName, password);

        if (await UnitOfWork.SaveChangesAsync() <= 0)
            throw new InvalidOperationException("Failed to update password in the database.");

        return true;
    }

    public async Task<Users?> RegisterAsync(Users users)
    {
        var userNameExists = await UsersRepository.GetByUserNameAsync(users.UserName!);

        if (userNameExists != null)
            throw new InvalidOperationException("Username already exists.");

        var emailExists = await UsersRepository.GetByEmailAsync(users.Email!);

        if (emailExists != null)
            throw new InvalidOperationException("Email already exists.");

        users.CreatedBy = users.Email;

        var addedEntity = await UsersRepository.AddAsync(users) ?? throw new InvalidOperationException("User registration failed.");
        
        var saveResult = await unitOfWork.SaveChangesAsync();

        if (saveResult <= 0)
            throw new InvalidOperationException("Failed to save user to the database.");

        return addedEntity;
    }
}
