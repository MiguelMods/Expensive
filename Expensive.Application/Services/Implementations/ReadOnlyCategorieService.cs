using Expensive.Application.Repository.Contract;
using Expensive.Application.Responses;
using Expensive.Application.Services.Contracts;
using Expensive.Domain.Entities;
using System.Linq.Expressions;

namespace Expensive.Application.Services.Implementations;

public class ReadOnlyCategorieService(IUnitOfWork unitOfWork) : ReadOnlyService<Categories, CategorieResponse>(unitOfWork), IReadOnlyCategorieService
{
    public async Task<CategorieResponse?> GetByParameterNameAndValueAsync(string parameterName, string parameterValue)
    {
        var expression = parameterName switch
        {
            "Name" => (Expression<Func<Categories, bool>>)(c => c.Name == parameterValue),
            "CategorieId" => c => c.CategorieId == long.Parse(parameterValue),
            "Operation" => c => c.Operation == parameterValue,
            _ => throw new ArgumentException("Invalid parameter name")
        };

        var result = await GetByExpressionAsync(expression);

        return result;
    }
    public async Task<IEnumerable<CategorieResponse?>> GetByLikeByParameterNameAndValueAsync(string parameterName, string parameterValue)
    {
        var expression = parameterName switch
        {
            "Name" => (Expression<Func<Categories, bool>>)(c => c.Name.Contains(parameterValue)),
            "CategorieId" => c => c.CategorieId.ToString().Contains(parameterValue),
            "Operation" => c => c.Operation.Contains(parameterValue),
            _ => throw new ArgumentException("Invalid parameter name")
        };
        var result = await GetByLikeByExpressionAsync(expression);
        return result;
    }
}