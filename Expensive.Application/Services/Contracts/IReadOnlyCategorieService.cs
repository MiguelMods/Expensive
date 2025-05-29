using Expensive.Application.Responses;
using Expensive.Domain.Entities;

namespace Expensive.Application.Services.Contracts;

public interface IReadOnlyCategorieService : IReadOnlyService<Categories, CategorieResponse>
{
    Task<CategorieResponse?> GetByParameterNameAndValueAsync(string parameterName, string ParameterValue);
    Task<IEnumerable<CategorieResponse?>> GetByLikeByParameterNameAndValueAsync(string parameterName, string ParameterValue);
}