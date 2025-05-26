using Expensive.Domain.Entities;
using Expensive.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Expensive.Persistance.Context;

public class ExpensiveApplicationDataContext(DbContextOptions<ExpensiveApplicationDataContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Categories> Categories { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<UserCategories> UserCategories { get; set; }
    public DbSet<UserPaymentMethods> UserPaymentMethods { get; set; }
    public DbSet<PaymentMethods> PaymentMethods { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoriesEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserCategoriesEntityConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentMethodsEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserPaymentMethodsEntityConfiguration());
    }
}
