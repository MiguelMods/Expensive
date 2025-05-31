using Expensive.Application.Models.dto;
using Expensive.Application.Repository.Contract;
using Expensive.Domain.Entities;
using Expensive.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Expensive.Persistance.Repository.Implementations;

public class UserCategoriesRepository(ExpensiveApplicationDataContext expensiveApplicationDataContext) : IUserCategoriesRepository
{
    public ExpensiveApplicationDataContext ExpensiveApplicationDataContext { get; } = expensiveApplicationDataContext;

    public async Task<IEnumerable<CategoryDto?>> GetAllUserCategories(long userId)
    {
        var data = ExpensiveApplicationDataContext
                        .UserCategories
                        .Where(x => x.UserId == userId && x.IsDeleted != true)
                        .Select(x => (CategoryDto)x.Categorie);

        return await data.ToListAsync();
    }

    public Task<bool> AddUserCategorie(UserCategories categories)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateUserCategorie(UserCategories categories)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddDefaultUserCategories(long userId, List<UserCategories> categories)
    {
        await ExpensiveApplicationDataContext.UserCategories.AddRangeAsync(categories);
        return true;
    }
}
