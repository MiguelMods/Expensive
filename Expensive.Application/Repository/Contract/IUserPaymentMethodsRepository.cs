using Expensive.Application.Models.dto;
using Expensive.Domain.Entities;

namespace Expensive.Application.Repository.Contract;

public interface IUserPaymentMethodsRepository
{
    Task<UserPaymentMethodsDTO> GetByUserIdAsync(long userId);
    Task<PaymentMethodDTO> GetByUserPaymentMethodIdAsync(long userId, long paymentMethodId);
    Task<UserPaymentMethods?> AddUserPaymentMethodAsync(UserPaymentMethods userPaymentMethod);
    Task<UserPaymentMethods?> UpdateUserPaymentMethodAsync(UserPaymentMethods userPaymentMethod);
}
