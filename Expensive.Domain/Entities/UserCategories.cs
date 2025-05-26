namespace Expensive.Domain.Entities;

public class UserCategories : BaseEntity
{
    public long UserCategorieId { get; set; }
    public int UserId { get; set; }
    public Users? User { get; set; }
    public int CategorieId { get; set; }
    public Categories? Categorie { get; set; }
}
