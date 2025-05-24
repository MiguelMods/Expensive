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
        => await ExpensiveApplicationDataContext.Set<Type>().ToListAsync();
    public async Task<Type?> GetByRowGuidAsync(string rowGuid)
        => await ExpensiveApplicationDataContext.Set<Type>().FirstOrDefaultAsync(x => x.RowGuid == rowGuid);
    public async Task<Type?> GetByExpressionAsync(Expression<Func<Type, bool>> expression)
        => await ExpensiveApplicationDataContext.Set<Type>().FirstOrDefaultAsync(expression);
    public Task<Type?> AddAsync(Type entity)
    {
        throw new NotImplementedException();
    }
    public Task<Type?> UpdateAsync(Type entity)
    {
        throw new NotImplementedException();
    }
    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
