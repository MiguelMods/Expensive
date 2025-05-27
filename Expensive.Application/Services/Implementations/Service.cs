using Expensive.Application.Repository.Contract;
using Expensive.Application.Services.Contracts;
using Expensive.Common.Intergace;
using Expensive.Common.Response;
using Expensive.Domain.Entities;
using System.Linq.Expressions;

namespace Expensive.Application.Services.Implementations;

public class Service<TEntity, TResponse>(IUnitOfWork unitOfWork) : IService<TEntity, TResponse>
    where TEntity : BaseEntity
    where TResponse : BaseResponse, ICustomMapToResponse<TEntity, TResponse>
{
    public IUnitOfWork UnitOfWork { get; } = unitOfWork;

    public async Task<IEnumerable<TResponse?>> GetAllAsync()
    {
        var respository = UnitOfWork.GenericRepositoryWithResponse<TEntity, TResponse>();
        var entities = await respository.GetAllAsync();
        return entities;
    }

    public async Task<TResponse?> GetByRowGuidAsync(string rowguid)
    {
        var respository = UnitOfWork.GenericRepositoryWithResponse<TEntity, TResponse>();
        var entities = await respository.GetByRowGuidAsync(rowguid);
        return entities ?? default;
    }

    public async Task<TResponse?> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression)
    {
        var respository = UnitOfWork.GenericRepositoryWithResponse<TEntity, TResponse>();
        var entities = await respository.GetByExpressionAsync(expression);
        return entities ?? default;
    }

    public Task<IEnumerable<TResponse>> GetByAllByExpressionAsync(Expression<Func<TEntity, bool>> expression)
    {
        var respository = UnitOfWork.GenericRepositoryWithResponse<TEntity, TResponse>();
        var entities = respository.GetByAllByExpressionAsync(expression);
        return entities;
    }

    public async Task<TResponse> AddAsync(TEntity entity)
    {
        var respository = UnitOfWork.GenericRepositoryWithResponse<TEntity, TResponse>();
        var response = await respository.AddAsync(entity);

        var result = await UnitOfWork.SaveChangesAsync();

        if (result <= 0)
        {
            throw new Exception("Failed to add entity.");
        }

        return response;
    }

    public Task<TResponse> UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<TResponse> Delete(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
