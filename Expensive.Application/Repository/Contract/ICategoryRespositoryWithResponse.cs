using Expensive.Common.Response;
using Expensive.Domain.Entities;

namespace Expensive.Application.Repository.Contract;

public interface ICategoryRespositoryWithResponse : IGenericRepositoryWithResponse<Categories, CategorieResponse>
{
    
}