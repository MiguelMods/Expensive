using Expensive.Common.Intergace;
using Expensive.Common.Response;
using Expensive.Domain.Entities;

namespace Expensive.Application.Repository.Contract;

public interface IUnitOfWork : IDisposable
{
    ICategoriesRepository Categories { get; }
    ICategoryRespositoryWithResponse CategoryRespositoryWithResponse { get; }
    IGenericRepository<Type> GenericRepository<Type>() where Type : BaseEntity;
    IGenericRepositoryWithResponse<TEntity, TResponse> GenericRepositoryWithResponse<TEntity, TResponse>()
        where TEntity : BaseEntity
        where TResponse : BaseResponse, ICustomMapToResponse<TEntity, TResponse>;
    Task<int> SaveChangesAsync();
}
