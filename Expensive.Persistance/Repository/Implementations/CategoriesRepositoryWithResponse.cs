using Expensive.Application.Repository.Contract;
using Expensive.Common.Response;
using Expensive.Domain.Entities;
using Expensive.Persistance.Context;

namespace Expensive.Persistance.Repository.Implementations;

public class CategoriesRepositoryWithResponse(ExpensiveApplicationDataContext expensiveApplicationDataContext) : GenericRepositoryWithResponse<Categories, CategorieResponse>(expensiveApplicationDataContext), ICategoryRespositoryWithResponse
{
}
