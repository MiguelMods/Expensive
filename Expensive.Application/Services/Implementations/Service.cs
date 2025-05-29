using Expensive.Application.Repository.Contract;
using Expensive.Application.Services.Contracts;
using Expensive.Domain.Entities;

namespace Expensive.Application.Services.Implementations;

public class Service<Type>(IUnitOfWork unitOfWork) : IService<Type> where Type : BaseEntity
{
    public IUnitOfWork UnitOfWork { get; } = unitOfWork;
    public IGenericRepository<Type> GenericRepository => UnitOfWork.GenericRepository<Type>();
    public async Task<IEnumerable<Type?>> GetAllAsync()
    {
        var entities = await GenericRepository.GetAllAsync();
        return entities;
    }

    public async Task<Type?> GetByRowGuidAsync(string rowGuid)
    {
        var entities = await GenericRepository.GetByRowGuidAsync(rowGuid);
        return entities;
    }

    public async Task<Type?> AddAsync(Type entity)
    {
        var addedEntity = await GenericRepository.AddAsync(entity) ?? throw new InvalidOperationException("Failed to add entity.");
        
        var saveResult = await UnitOfWork.SaveChangesAsync();

        if(saveResult <= 0)
            throw new InvalidOperationException("Failed to save changes to the database.");

        return addedEntity;
    }

    public async Task<Type?> UpdateAsync(Type entity)
    {
        var entityToUpdateExist = await GenericRepository.GetByRowGuidAsync(entity.RowGuid);

        if (entityToUpdateExist == null)
            throw new InvalidOperationException("Entity not found");

        var updateEntity = await GenericRepository.UpdateAsync(entity) ?? throw new InvalidOperationException("Failed to add entity.");
        
        var saveResult = await UnitOfWork.SaveChangesAsync();

        if (saveResult <= 0)
            throw new InvalidOperationException("Failed to save changes to the database.");

        return updateEntity;
    }

    public async Task<bool> DeleteAsync(string rowGuid)
    {
        var entity = await GenericRepository.GetByRowGuidAsync(rowGuid) ?? throw new InvalidOperationException($"Entity with RowGuid {rowGuid} not found.");
        
        var deleteEntity = await GenericRepository.DeleteAsync(entity.RowGuid!);
        
        if (!deleteEntity)
            throw new InvalidOperationException($"Failed to delete entity with RowGuid {rowGuid}.");

        var saveResult = await UnitOfWork.SaveChangesAsync();

        if (saveResult <= 0)
            throw new InvalidOperationException("Failed to save changes to the database.");

        return true;
    }
}