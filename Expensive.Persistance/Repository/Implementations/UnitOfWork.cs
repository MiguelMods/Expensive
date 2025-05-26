using Expensive.Application.Repository.Contract;
using Expensive.Common.Intergace;
using Expensive.Common.Response;
using Expensive.Domain.Entities;
using Expensive.Persistance.Context;

namespace Expensive.Persistance.Repository.Implementations;

public class UnitOfWork(ExpensiveApplicationDataContext expensiveApplicationDataContext) : IUnitOfWork
{
    public ICategoriesRepository Categories => new CategoriesRepository(expensiveApplicationDataContext);
    public ICategoryRespositoryWithResponse CategoryRespositoryWithResponse => new CategoriesRepositoryWithResponse(expensiveApplicationDataContext);
    public IGenericRepository<Type> GenericRepository<Type>() where Type : BaseEntity => new GenericRepository<Type>(expensiveApplicationDataContext);

        public async Task<int> SaveChangesAsync()
    {
        expensiveApplicationDataContext.ChangeTracker.DetectChanges();
        return await expensiveApplicationDataContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            expensiveApplicationDataContext.Dispose();
        }
    }

    public IGenericRepositoryWithResponse<TEntity, TResponse> GenericRepositoryWithResponse<TEntity, TResponse>()
        where TEntity : BaseEntity
        where TResponse : BaseResponse, ICustomMapToResponse<TEntity, TResponse>
    {
        return new GenericRepositoryWithResponse<TEntity, TResponse>(expensiveApplicationDataContext);
    }
}
