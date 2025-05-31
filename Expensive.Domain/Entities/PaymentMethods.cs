namespace Expensive.Domain.Entities;

public class PaymentMethods : BaseEntity
{
    public long PaymentMethodId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsDefault { get; set; }
    public IEnumerable<UserPaymentMethods>? UserPaymentMethods { get; set; }
}
