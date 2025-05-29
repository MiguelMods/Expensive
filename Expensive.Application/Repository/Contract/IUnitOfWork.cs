using Expensive.Domain.Entities;

namespace Expensive.Application.Repository.Contract;

public interface IUnitOfWork : IDisposable
{
    ICategoriesRepository Categories { get; }
    IUsersRepository Users { get; }
    IPaymentMethodsRepository PaymentMethods { get; }
    IGenericRepository<Type> GenericRepository<Type>() where Type : BaseEntity;
    Task<int> SaveChangesAsync();
}
