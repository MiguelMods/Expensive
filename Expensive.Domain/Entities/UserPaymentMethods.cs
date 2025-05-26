namespace Expensive.Domain.Entities;

public class  UserPaymentMethods : BaseEntity
{
    public int UserPaymentMethodId { get; set; }
    public int UserId { get; set; }
    public Users? User { get; set; }
    public int PaymentMethodId { get; set; }
    public PaymentMethods? PaymentMethod { get; set; }
}
