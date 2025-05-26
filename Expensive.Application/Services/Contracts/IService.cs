using Expensive.Common.Results;

namespace Expensive.Application.Services.Contracts;

public interface IService<TEntity, TResult> where TEntity : class where TResult : class
{
    Task<IEnumerable<TResult>> GetAllAsync();
    Task<TResult> GetByRowGuidAsync(string rowguid);
}
