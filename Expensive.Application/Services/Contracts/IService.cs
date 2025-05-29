using Expensive.Domain.Entities;

namespace Expensive.Application.Services.Contracts;

public interface IService<Type> where Type : BaseEntity 
{
    Task<IEnumerable<Type?>> GetAllAsync();
    Task<Type?> GetByRowGuidAsync(string rowGuid);
    Task<Type?> AddAsync(Type entity);
    Task<Type?> UpdateAsync(Type entity);
    Task<bool> DeleteAsync(string rowGuid);
}
