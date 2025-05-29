using Expensive.Application.Responses;
using Expensive.Domain.Entities;

namespace Expensive.Application.Contracts
{
    public interface IMapResponse<TEntity, TResponse> where TEntity : BaseEntity where TResponse : BaseResponse
    {
        TResponse MapToResponse(TEntity entity);
    }
}
