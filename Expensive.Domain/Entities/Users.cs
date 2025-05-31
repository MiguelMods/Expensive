namespace Expensive.Domain.Entities;

public class Users : BaseEntity
{
    public long UserId { get; set; }
    public string? FirtsName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public ICollection<UserCategories>? UserCategories { get; set; }
    public IEnumerable<UserPaymentMethods>? UserPaymentMethods { get; set; }
}
