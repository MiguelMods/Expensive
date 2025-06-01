using Expensive.Application.Models;
using Expensive.Application.Models.dto;
using Expensive.Application.Repository.Contract;
using Expensive.Application.Services.Contracts;
using Expensive.Domain.Entities;

namespace Expensive.Application.Services.Implementations;

public class UserCategoriesService(IUnitOfWork unitOfWork, IHttpContextUserHelper httpContextUserHelper) : IUserCategoriesService
{
    public IUnitOfWork UnitOfWork { get; } = unitOfWork;
    private UserToken UserToken => httpContextUserHelper.GetUserToken() ?? throw new ArgumentException("User token is null.");
    public async Task<IEnumerable<CategoryDto?>> GetAllUserCategories(long userId)
    => await UnitOfWork.UserCategoriesRepository.GetAllUserCategories(userId);

    public async Task<bool> AddDefaultUserCategories(long userId)
    {
        var userToken = httpContextUserHelper.GetUserToken() ?? throw new ArgumentException("User token is null.");
        var defaultCategories = await UnitOfWork.Categories.GetByLikeExpressionAsync(x => x.IsDefault == true);

        if (defaultCategories == null || !defaultCategories.Any())
            throw new ArgumentException("No default categories found.");

        var addedDefaultCategories = await UnitOfWork.UserCategoriesRepository.AddDefaultUserCategories(userId, [.. defaultCategories.Select(x => new UserCategories
        {
            UserId = userId,
            CategorieId = x.CategorieId,
            IsActive = true,
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = userToken.Name ?? "default",
        })]);

        if (!addedDefaultCategories)
            throw new Exception("Failed to add default user categories.");

        var saveResult = await UnitOfWork.SaveChangesAsync();

        if(saveResult <= 0)
            throw new Exception("Failed to save changes after adding default user categories.");

        return true;
    }

    public async Task<CategoryDto> AddNewCategorieToUser(long userId, CategoryDto categoryDto)
    {
        var addedCategory = await UnitOfWork.Categories.AddAsync(new Categories
        {
            Name = categoryDto.Name,
            Description = categoryDto.Description,
            IsActive = true,
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = UserToken.Name
        });
        
        var saveResult = await UnitOfWork.SaveChangesAsync();

        if (saveResult <= 0 || addedCategory == null)
            throw new Exception("Failed to add new category.");

        var userCategory = new UserCategories
        {
            UserId = userId,
            CategorieId = addedCategory.CategorieId,
            IsActive = true,
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = UserToken.Name
        };

        var addedUserCategory = await UnitOfWork.UserCategoriesRepository.AddUserCategorie(userCategory);

        saveResult = await UnitOfWork.SaveChangesAsync();

        if (saveResult <= 0 || addedUserCategory == null)
            throw new Exception("Failed to add user category.");

        return (CategoryDto)addedCategory;
    }

    public async Task<CategoryDto> UpdateUserCategorie(CategoryDto categoryDto)
    {
        var updatedCategory = await UnitOfWork.Categories.UpdateAsync(new Categories
        {
            CategorieId = categoryDto.CategorieId,
            Name = categoryDto.Name,
            Description = categoryDto.Description,
            IsActive = categoryDto.IsActive,
            IsDeleted = categoryDto.IsDeleted,
            UpdatedAt = DateTime.UtcNow,
            UpdatedBy = UserToken.Name
        });
        
        var saveResult = await UnitOfWork.SaveChangesAsync();
        
        if (saveResult <= 0 || updatedCategory == null)
            throw new Exception("Failed to update category.");

        return (CategoryDto)updatedCategory;
    }
}
