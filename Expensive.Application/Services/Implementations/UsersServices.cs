using Expensive.Application.Repository.Contract;
using Expensive.Application.Services.Contracts;
using Expensive.Domain.Entities;

namespace Expensive.Application.Services.Implementations;

public class UsersServices(IUnitOfWork unitOfWork) : Service<Users>(unitOfWork), IUsersService
{
    IUsersRepository UsersRepository => unitOfWork.Users;

    public Task<Users?> GetByEmailAsync(string email)
        => UsersRepository.GetByEmailAsync(email);

    public Task<Users?> GetByUserNameAndPassword(string userName, string password)
        => UsersRepository.GetByUserNameAndPassword(userName, password);

    public Task<Users?> GetByUserNameAsync(string userName)
        => UsersRepository.GetByUserNameAsync(userName);

    public Task<bool> UpdateOldPasswordToPassword(string userName, string oldPassword, string newPassword)
        => UsersRepository.UpdateOldPasswordToPassword(userName, oldPassword, newPassword);

    public Task<bool> UpdateUserPassword(string userName, string password)
        => UsersRepository.UpdateUserPassword(userName, password);

    public async Task<Users?> RegisterAsync(Users users)
    {
        var userNameExists = UsersRepository.GetByUserNameAsync(users.UserName!);

        if (userNameExists != null)
            throw new InvalidOperationException("Username already exists.");

        var emailExists = UsersRepository.GetByEmailAsync(users.Email!);

        if (emailExists != null)
            throw new InvalidOperationException("Email already exists.");

        var addedEntity = await UsersRepository.AddAsync(users) ?? throw new InvalidOperationException("User registration failed.");
        
        var saveResult = await unitOfWork.SaveChangesAsync();

        if (saveResult <= 0)
            throw new InvalidOperationException("Failed to save user to the database.");

        return addedEntity;
    }
}
