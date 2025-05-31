namespace Expensive.Domain.Entities;

public class Entries : BaseEntity
{
    public long EntryId { get; set; }
    public decimal Amount { get; set; }
    public long UserId { get; set; }
    public Users? User { get; set; }
    public long CategorieId { get; set; }
    public Categories? Categorie { get; set; }
    public long PaymentMethodId { get; set; }
    public PaymentMethods? PaymentMethod { get; set; }
}