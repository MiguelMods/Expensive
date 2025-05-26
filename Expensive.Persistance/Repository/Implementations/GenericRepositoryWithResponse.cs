using Expensive.Application.Repository.Contract;
using Expensive.Common.Intergace;
using Expensive.Common.Response;
using Expensive.Domain.Entities;
using Expensive.Persistance.Context;

namespace Expensive.Persistance.Repository.Implementations;

public class GenericRepositoryWithResponse<TEntity, TResponse>(ExpensiveApplicationDataContext expensiveApplicationDataContext) : IGenericRepositoryWithResponse<TEntity, TResponse> where TEntity : BaseEntity where TResponse : BaseResponse, ICustomMapToResponse<TEntity, TResponse>
{
    public ExpensiveApplicationDataContext ExpensiveApplicationDataContext { get; } = expensiveApplicationDataContext;

    public Task<IEnumerable<TResponse>> GetAllAsync()
    {
        var data = ExpensiveApplicationDataContext.Set<TEntity>().AsEnumerable();
        var response = data.Select(Map);
        return Task.FromResult(response);
    }

    public Task<TResponse?> GetByRowGuidAsync(string rowGuid)
    {
        var data = ExpensiveApplicationDataContext.Set<TEntity>().FirstOrDefault(x => x.RowGuid == rowGuid);
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

    private TResponse Map(TEntity entity)
    {
        var response = Activator.CreateInstance<TResponse>();
        if (response is ICustomMapToResponse<TEntity, TResponse> mapper)
        {
            return mapper.MapToResponse(entity);
        }
        else
        {
            return default(TResponse);
        }
    }
}