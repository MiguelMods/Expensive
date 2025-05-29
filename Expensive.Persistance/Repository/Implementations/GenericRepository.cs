using Expensive.Application.Repository.Contract;
using Expensive.Domain.Entities;
using Expensive.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Expensive.Persistance.Repository.Implementations;

public class GenericRepository<Type>(ExpensiveApplicationDataContext expensiveApplicationDataContext) : IGenericRepository<Type> where Type : BaseEntity
{
    public ExpensiveApplicationDataContext ExpensiveApplicationDataContext { get; } = expensiveApplicationDataContext;

    public async Task<IEnumerable<Type?>> GetAllAsync()
        => await ExpensiveApplicationDataContext.Set<Type>().Where(x => x.IsDeleted != true).ToListAsync();
    public async Task<Type?> GetByRowGuidAsync(string rowGuid)
        => await ExpensiveApplicationDataContext.Set<Type>().Where(x => x.RowGuid == rowGuid && x.IsDeleted != true).FirstOrDefaultAsync();
    public async Task<Type?> GetByExpressionAsync(Expression<Func<Type, bool>> expression)
        => await ExpensiveApplicationDataContext.Set<Type>().Where(x => x.IsDeleted != true).FirstOrDefaultAsync(expression);
    public async Task<IEnumerable<Type?>> GetByLikeExpressionAsync(Expression<Func<Type, bool>> expression)
        => await ExpensiveApplicationDataContext.Set<Type>().Where(x => x.IsDeleted != true).Where(expression).ToListAsync();
    public async Task<Type?> AddAsync(Type entity)
    {
        var newEntity = await ExpensiveApplicationDataContext.Set<Type>().AddAsync(entity);
        return newEntity.Entity;
    }
    public Task<Type?> UpdateAsync(Type entity)
    {
        var updateEntity = ExpensiveApplicationDataContext.Set<Type>().Update(entity);
        return Task.FromResult<Type?>(updateEntity.Entity);
    }
    public async Task<bool> DeleteAsync(string rowGuid)
    {
        var entity = await ExpensiveApplicationDataContext.Set<Type>().FindAsync(rowGuid) ?? throw new Exception($"Entity with Id: {rowGuid} not found");

        if (entity.IsDeleted)
            return true;

        entity.IsDeleted = true;
        entity.UpdatedAt = DateTime.UtcNow;
        ExpensiveApplicationDataContext.Set<Type>().Update(entity);
        
        return true;
    }
}
