using Expensive.Application.Models.dto;
using Expensive.Domain.Entities;

namespace Expensive.Application.Repository.Contract;

public interface IUserCategoriesRepository
{
    Task<IEnumerable<CategoryDto?>> GetAllUserCategories(long userId);
    Task<bool> AddUserCategorie(UserCategories categories);
    Task<bool> UpdateUserCategorie(UserCategories categories);
    Task<bool> AddDefaultUserCategories(long userId, List<UserCategories> categories);
}
