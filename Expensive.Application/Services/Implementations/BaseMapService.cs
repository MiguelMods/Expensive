using Expensive.Application.Contracts;
using Expensive.Application.Responses;
using Expensive.Domain.Entities;

namespace Expensive.Application.Services.Implementations;

public abstract class BaseMapService<TEntity, TResponse> where TEntity : BaseEntity where TResponse : BaseResponse, IMapResponse<TEntity, TResponse>
{
    public TResponse? Map(TEntity entity)
    {
        var mapper = Activator.CreateInstance<TResponse>();

        return mapper is null
            ? throw new Exception($"No se puede Mapear el objeto de {typeof(TEntity)} a {typeof(TResponse)}")
            : mapper.MapToResponse(entity);
    }
}