namespace Expensive.Application.Services.Contracts;

public interface IAddService<TEntity>
{
    Task<TEntity> AddAsync(TEntity entity);
}

public interface IAddService<TEntity, TResponse>
{
    Task<TResponse> AddAsync(TEntity entity);
}

public interface IUpdateService<TEntity>
{
    Task<TEntity> UpdateAsync(TEntity entity);
}

public interface IUpdateService<TEntity, TResponse>
{
    Task<TResponse> UpdateAsync(TEntity entity);
}