using Expensive.Application.Models;
using Expensive.Application.Repository.Contract;
using Expensive.Application.Services.Contracts;
using Expensive.Domain.Entities;

namespace Expensive.Application.Services.Implementations;

public class UsersService(IUnitOfWork unitOfWork, IHashPassordService hashPassordService, IHttpContextUserHelper httpContextUserHelper) : Service<Users>(unitOfWork), IUsersService
{
    public IUsersRepository UsersRepository => unitOfWork.Users;
    public IHashPassordService HashPassordService { get; } = hashPassordService;
    private readonly UserToken userToken = httpContextUserHelper.GetUserToken();
    private readonly string invalidUserNamePasswordMessage = "Invalid username or password.";

    public Task<Users?> GetByEmailAsync(string email)
        => UsersRepository.GetByEmailAsync(email);

    public async Task<Users?> GetByUserNameAndPassword(string userName, string password)
    { 
        var userByUserName = await UsersRepository.GetByUserNameAndPassword(userName);
        
        var passwordIsValid = await HashPassordService.VerifyPassword(userByUserName?.Password!, password);

        if(!passwordIsValid)
            throw new Exception(invalidUserNamePasswordMessage);

        return userByUserName;
    }

    public Task<Users?> GetByUserNameAsync(string userName)
        => UsersRepository.GetByUserNameAsync(userName);

    public async Task<bool> UpdateOldPasswordToPassword(string userName, string oldPassword, string newPassword) 
    {
        var userByUserName = await UsersRepository.GetByUserNameAndPassword(userName) ?? throw new Exception(invalidUserNamePasswordMessage);

        var oldPasswordIsValid = await HashPassordService.VerifyPassword(userByUserName?.Password!, oldPassword);

        if (!oldPasswordIsValid)
            throw new Exception(invalidUserNamePasswordMessage);

        var hashedNewPassword = await HashPassordService.HashPassword(newPassword);

        await UsersRepository.UpdateOldPasswordToPassword(userName, userByUserName?.Password!, hashedNewPassword, userToken?.Name!);

        if (await unitOfWork.SaveChangesAsync() <= 0)
            throw new InvalidOperationException("Failed to update password in the database.");

        return true;
    }
         
    public async Task<bool> UpdateUserPassword(string userName, string password) 
    {
        var userByUserName = await UsersRepository.GetByUserNameAsync(userName) ?? throw new Exception(invalidUserNamePasswordMessage);

        var passwordIsValid = await HashPassordService.VerifyPassword(userByUserName?.Password!, password);

        if (!passwordIsValid)
            throw new Exception(invalidUserNamePasswordMessage);

        var hashedPassword = await HashPassordService.HashPassword(password);

        await UsersRepository.UpdateUserPassword(userName, hashedPassword, userToken?.Name!);

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

        users.Password = await HashPassordService.HashPassword(users.Password!);

        var addedEntity = await UsersRepository.AddAsync(users) ?? throw new InvalidOperationException("User registration failed.");
        
        var saveResult = await unitOfWork.SaveChangesAsync();

        if (saveResult <= 0)
            throw new InvalidOperationException("Failed to save user to the database.");

        return addedEntity;
    }
}
