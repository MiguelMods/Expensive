namespace Expensive.Application.Services.Contracts;

public interface IUserPaymentsService
{
    Task GetAllUserPaymentAsync(long userId);
    Task GetUserPaymentByIdAsync(long userId, long paymentId);
    Task AddUserPaymentAsync();
    Task UpdateUserPaymentAsync();
}