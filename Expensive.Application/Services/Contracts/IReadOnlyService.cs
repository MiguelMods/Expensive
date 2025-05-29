using Expensive.Application.Contracts;
using Expensive.Application.Responses;
using Expensive.Domain.Entities;
using System.Linq.Expressions;

namespace Expensive.Application.Services.Contracts;

public interface IReadOnlyService<TEntity, TResponse> where TEntity : BaseEntity where TResponse : BaseResponse, IMapResponse<TEntity, TResponse>
{
    Task<IEnumerable<TResponse?>> GetAllAsync();
    Task<IEnumerable<TResponse?>> GetByLikeByExpressionAsync(Expression<Func<TEntity, bool>> expression);
    Task<TResponse?> GetByRowGuidAsync(string rowGuid);
    Task<TResponse?> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression);
}
