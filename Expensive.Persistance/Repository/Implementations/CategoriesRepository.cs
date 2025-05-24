using Expensive.Application.Repository.Contract;
using Expensive.Domain.Entities;
using Expensive.Persistance.Context;

namespace Expensive.Persistance.Repository.Implementations;

public class CategoriesRepository(ExpensiveApplicationDataContext expensiveApplicationDataContext) : GenericRepository<Categories>(expensiveApplicationDataContext), ICategoriesRepository
{
}
