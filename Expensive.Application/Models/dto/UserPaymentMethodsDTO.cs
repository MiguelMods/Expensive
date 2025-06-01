using Expensive.Application.Response;

namespace Expensive.Application.Models.dto;

public class UserPaymentMethodsDTO
{
    public IEnumerable<PaymentMethodDTO>? PaymentMethods { get; set; }
}