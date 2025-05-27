using Expensive.Common.Intergace;
using Expensive.Common.Response;
using Expensive.Domain.Entities;
using System.Linq.Expressions;

namespace Expensive.Application.Services.Contracts;

public interface IService<TEntity, TResponse> where TEntity : BaseEntity where TResponse : BaseResponse, ICustomMapToResponse<TEntity, TResponse>
{
    Task<IEnumerable<TResponse?>> GetAllAsync();
    Task<TResponse?> GetByRowGuidAsync(string rowguid);
    Task<TResponse?> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression);
    Task<IEnumerable<TResponse>> GetByAllByExpressionAsync(Expression<Func<TEntity, bool>> expression);
    Task<TResponse> AddAsync(TEntity entity);
    Task<TResponse> UpdateAsync(TEntity entity);
    Task<TResponse> Delete(TEntity entity);
}
