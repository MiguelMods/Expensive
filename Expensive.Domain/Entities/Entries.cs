namespace Expensive.Domain.Entities;

public class Entries : BaseEntity
{
    public int EntryId { get; set; }
    public decimal Amount { get; set; }
    public int UserId { get; set; }
    public Users? User { get; set; }
    public int CategorieId { get; set; }
    public Categories? Categorie { get; set; }
    public int PaymentMethodId { get; set; }
    public PaymentMethods? PaymentMethod { get; set; }
}