using Expensive.Application.Repository.Contract;
using Expensive.Application.Services.Contracts;

namespace Expensive.Application.Services.Implementations;

public class UserPaymentsService(IUnitOfWork unitOfWork) : IUserPaymentsService
{
    public IUnitOfWork UnitOfWork { get; } = unitOfWork;

    public Task GetAllUserPaymentAsync(long userId)
    {
        throw new NotImplementedException();
    }
    public Task GetUserPaymentByIdAsync(long userId, long paymentId)
    {
        throw new NotImplementedException();
    }
    public Task AddUserPaymentAsync()
    {
        throw new NotImplementedException();
    }
    public Task UpdateUserPaymentAsync()
    {
        throw new NotImplementedException();
    }
}
