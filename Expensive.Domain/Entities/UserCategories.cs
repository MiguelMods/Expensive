namespace Expensive.Domain.Entities;

public class UserCategories : BaseEntity
{
    public long UserCategorieId { get; set; }
    public long UserId { get; set; }
    public Users? User { get; set; }
    public long CategorieId { get; set; }
    public Categories? Categorie { get; set; }
}
