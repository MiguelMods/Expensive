namespace Expensive.Domain.Entities;

public class  UserPaymentMethods : BaseEntity
{
    public long UserPaymentMethodId { get; set; }
    public long UserId { get; set; }
    public Users? User { get; set; }
    public long PaymentMethodId { get; set; }
    public PaymentMethods? PaymentMethod { get; set; }
}
