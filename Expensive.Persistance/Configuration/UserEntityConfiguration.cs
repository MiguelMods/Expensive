using Expensive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expensive.Persistance.Configuration;

public class UserEntityConfiguration : IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.ToTable("Users", "dbo");
        builder.HasKey(x => x.UserId);
        builder.Property(x => x.FirtsName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(200);
        builder.HasIndex(x => x.Email).IsUnique().HasDatabaseName("IX_Users_Email");
        builder.Property(x => x.UserName).IsRequired().HasMaxLength(100);
        builder.HasIndex(x => x.UserName).IsUnique().HasDatabaseName("IX_Users_UserName");
        builder.Property(x => x.Password).IsRequired().HasMaxLength(200);
        builder.Property(x => x.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.IsActive).HasDefaultValue(true);
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        builder.Property(x => x.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(x => x.RowGuid).IsUnique().HasDatabaseName("IX_Categories_RowGuid");
        builder.HasMany(x => x.UserCategories)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(x => x.UserPaymentMethods)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasData(new Users 
        {
            UserId = 1,
            FirtsName = "Miguel Jose",
            LastName = "Mata Ramos",
            Email = "miguelmodd@gmail.com",
            UserName = "miguelmodd",
            Password = "jose@123A",
            CreatedBy = "System"
        });
    }
}