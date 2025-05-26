using Expensive.Application.Repository.Contract;
using Expensive.Application.Services.Contracts;
using Expensive.Common.Intergace;
using Expensive.Common.Response;
using Expensive.Domain.Entities;

namespace Expensive.Application.Services.Implementations;

public class Service<TEntity, TResponse>(IUnitOfWork unitOfWork) : IService<TEntity, TResponse>
    where TEntity : BaseEntity
    where TResponse : BaseResponse, ICustomMapToResponse<TEntity, TResponse>
{
    public IUnitOfWork UnitOfWork { get; } = unitOfWork;

    public async Task<IEnumerable<TResponse>> GetAllAsync()
    {
        var respository = UnitOfWork.GenericRepositoryWithResponse<TEntity, TResponse>();
        var entities = await respository.GetAllAsync();
        return entities;
    }

    public async Task<TResponse> GetByRowGuidAsync(string rowguid)
    {
        var respository = UnitOfWork.GenericRepositoryWithResponse<TEntity, TResponse>();
        var entities = await respository.GetByRowGuidAsync(rowguid);
        return entities ?? default;
    }
}
