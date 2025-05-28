using Expensive.Domain.Entities;
using System.Linq.Expressions;

namespace Expensive.Application.Services.Contracts;

public interface IService<Type> where Type : BaseEntity 
{
    Task<IEnumerable<Type?>> GetAllAsync();
    Task<Type?> GetByRowGuidAsync(string rowGuid);
    Task<Type?> GetByExpressionAsync(Expression<Func<Type, bool>> expression);
    Task<Type?> AddAsync(Type entity);
    Task<Type?> UpdateAsync(Type entity);
    Task<bool> DeleteAsync(int id);
}
