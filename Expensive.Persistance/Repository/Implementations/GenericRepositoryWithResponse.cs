using Expensive.Application.Repository.Contract;
using Expensive.Common.Intergace;
using Expensive.Common.Response;
using Expensive.Domain.Entities;
using Expensive.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Expensive.Persistance.Repository.Implementations;

public class GenericRepositoryWithResponse<TEntity, TResponse>(ExpensiveApplicationDataContext expensiveApplicationDataContext) : 
    IGenericRepositoryWithResponse<TEntity, TResponse> where TEntity : BaseEntity where TResponse : BaseResponse, ICustomMapToResponse<TEntity, TResponse>
{
    public ExpensiveApplicationDataContext ExpensiveApplicationDataContext { get; } = expensiveApplicationDataContext;
    public DbSet<TEntity> DbSet => ExpensiveApplicationDataContext.Set<TEntity>();
    public Task<IEnumerable<TResponse?>> GetAllAsync()
    {
        var data = DbSet.AsEnumerable();
        var response = data.Select(Map);
        return Task.FromResult(response);
    }

    public Task<TResponse?> GetByRowGuidAsync(string rowGuid)
    {
        var data = DbSet.FirstOrDefault(x => x.RowGuid == rowGuid);
        if (data == null)
        {
            return Task.FromResult<TResponse?>(null);
        }
        else
        {
            var response = Map(data);
            return Task.FromResult<TResponse?>(response);
        }
    }

    public async Task<TResponse?> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression)
    {
        var data = await DbSet.FirstOrDefaultAsync(expression);
        if (data == null)
        {
            return null;
        }
        else
        {
            var response = Map(data);
            return response;
        }
    }

    public async Task<IEnumerable<TResponse>> GetByAllByExpressionAsync(Expression<Func<TEntity, bool>> expression)
    {
        var data = await DbSet.Where(expression).ToListAsync();
        var response = data.Select(Map);
        return response;
    }

    public async Task<TResponse> AddAsync(TEntity entity)
    {
        var addEntity = await DbSet.AddAsync(entity);
        return Map(addEntity.Entity);
    }

    public Task<TResponse> UpdateAsync(TEntity entity)
    {
        var updateEntity = DbSet.Update(entity);
        return Task.FromResult(Map(updateEntity.Entity));
    }

    public Task<TResponse> Delete(TEntity entity)
    {
        var deleteEntity = DbSet.Remove(entity);
        return Task.FromResult(Map(deleteEntity.Entity));
    }

    private TResponse? Map(TEntity entity)
    {
        var response = Activator.CreateInstance<TResponse>();

        if (response is ICustomMapToResponse<TEntity, TResponse> mapper)
            return mapper.MapToResponse(entity);

        return null;
    }
}