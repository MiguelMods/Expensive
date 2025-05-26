using Expensive.Common.Response;
using Expensive.Domain.Entities;

namespace Expensive.Common.Intergace;

public interface ICustomMapToResponse<TEntity, TResponse> where TEntity : BaseEntity where TResponse : BaseResponse
{
    TResponse MapToResponse(TEntity entity);
}
