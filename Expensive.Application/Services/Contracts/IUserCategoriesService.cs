using Expensive.Application.Models.dto;

namespace Expensive.Application.Services.Contracts;

public interface IUserCategoriesService
{
    Task<IEnumerable<CategoryDto?>> GetAllUserCategories(long userId);
    Task<CategoryDto> AddNewCategorieToUser(long userId, CategoryDto categoryDto);
    Task<bool> AddDefaultUserCategories(long userId);
}
