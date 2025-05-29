using Expensive.Application.Repository.Contract;
using Expensive.Application.Services.Contracts;
using Expensive.Domain.Entities;
using System.Linq.Expressions;

namespace Expensive.Application.Services.Implementations;

public class Service<Type>(IUnitOfWork unitOfWork) : IService<Type> where Type : BaseEntity
{
    public IUnitOfWork UnitOfWork { get; } = unitOfWork;

    public Task<Type?> AddAsync(Type entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Type?>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Type?> GetByExpressionAsync(Expression<Func<Type, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<Type?> GetByRowGuidAsync(string rowGuid)
    {
        throw new NotImplementedException();
    }

    public Task<Type?> UpdateAsync(Type entity)
    {
        throw new NotImplementedException();
    }
}