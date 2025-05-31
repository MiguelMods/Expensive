namespace Expensive.Domain.Entities;

public class Categories : BaseEntity
{
    public long CategorieId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsDefault { get; set; }
    public string? Operation { get; set; }
    public ICollection<UserCategories>? UserCategories { get; set; }
}
