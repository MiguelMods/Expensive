namespace Expensive.Domain.Entities;

public class Categories : BaseEntity
{
    public int CategorieId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
