using Expensive.Common.Response;
using Expensive.Domain.Entities;

namespace Expensive.Application.Repository.Contract;

public interface IGenericRepositoryWithResponse<TEntity, TResponse> where TEntity : BaseEntity where TResponse : BaseResponse
{
    Task<IEnumerable<TResponse>> GetAllAsync();
    Task<TResponse?> GetByRowGuidAsync(string rowGuid);
}