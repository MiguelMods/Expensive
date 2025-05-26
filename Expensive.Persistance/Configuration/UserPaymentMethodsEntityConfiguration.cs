using Expensive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expensive.Persistance.Configuration;

public class UserPaymentMethodsEntityConfiguration : IEntityTypeConfiguration<UserPaymentMethods>
{
    public void Configure(EntityTypeBuilder<UserPaymentMethods> builder)
    {
        builder.ToTable("UserPaymentMethods", "dbo");
        builder.HasKey(upm => upm.UserPaymentMethodId);
        builder.HasIndex(upm => new { upm.UserId, upm.PaymentMethodId }).IsUnique().HasDatabaseName("IX_UserPaymentMethods_UserId_PaymentMethodId");
        builder.Property(x => x.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.IsActive).HasDefaultValue(true);
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        builder.Property(x => x.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(x => x.RowGuid).IsUnique().HasDatabaseName("IX_Categories_RowGuid");
        builder.HasOne(upm => upm.User)
               .WithMany(u => u.UserPaymentMethods)
               .HasForeignKey(upm => upm.UserId)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(upm => upm.PaymentMethod)
               .WithMany(pm => pm.UserPaymentMethods)
               .HasForeignKey(upm => upm.PaymentMethodId)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasData(new UserPaymentMethods
        {
            UserPaymentMethodId = 1,
            UserId = 1,
            PaymentMethodId = 1, 
            CreatedBy = "Created By Default"
        }, new UserPaymentMethods 
        {
            UserPaymentMethodId = 2,
            UserId = 1,
            PaymentMethodId = 2,
            CreatedBy = "Created By Default"
        }, new UserPaymentMethods
        {
            UserPaymentMethodId = 3,
            UserId = 1,
            PaymentMethodId = 3,
            CreatedBy = "Created By Default"
        });
    }
}