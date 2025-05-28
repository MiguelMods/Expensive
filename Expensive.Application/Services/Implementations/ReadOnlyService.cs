using Expensive.Application.Contracts;
using Expensive.Application.Repository.Contract;
using Expensive.Application.Responses;
using Expensive.Application.Services.Contracts;
using Expensive.Domain.Entities;
using System.Linq.Expressions;

namespace Expensive.Application.Services.Implementations;

public class ReadOnlyService<TEntity, TResponse>(IUnitOfWork unitOfWork) : BaseMapService<TEntity, TResponse>, IReadOnlyService<TEntity, TResponse> 
    where TEntity : BaseEntity where TResponse : BaseResponse, IMapResponse<TEntity, TResponse>
{
    public IUnitOfWork UnitOfWork { get; } = unitOfWork;
    public IGenericRepository<TEntity> Repository => UnitOfWork.GenericRepository<TEntity>();
    public async Task<IEnumerable<TResponse?>> GetAllAsync()
    {
        var data = await Repository.GetAllAsync();
        
        if (data is null || !data.Any())
            return [];

        var map = data.Select(Map!);

        return map;
    }
    public async Task<TResponse?> GetByRowGuidAsync(string rowGuid)
    {
        var data = await Repository.GetByRowGuidAsync(rowGuid);

        if(data is null)
            return null;

        return Map(data);
    }
    public async Task<TResponse?> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression)
    {
        var data = await Repository.GetByExpressionAsync(expression);
        
        if (data is null)
            return null;

        return Map(data);
    }
    public async Task<IEnumerable<TResponse?>> GetByLikeByExpressionAsync(Expression<Func<TEntity, bool>> expression) 
    {
        var data = await Repository.GetByLikeExpressionAsync(expression);
        
        if (data is null || !data.Any())
            return [];

        var map = data.Select(Map!);

        return map;
    }
}