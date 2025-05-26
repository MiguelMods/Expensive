using Expensive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expensive.Persistance.Configuration;

public class PaymentMethodsEntityConfiguration : IEntityTypeConfiguration<PaymentMethods>
{
    public void Configure(EntityTypeBuilder<PaymentMethods> builder)
    {
        builder.ToTable("PaymentMethods", "dbo");
        builder.HasKey(x => x.PaymentMethodId);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName("IX_PaymentMethods_Name");
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.IsDefault).HasDefaultValue(false);
        builder.Property(x => x.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.IsActive).HasDefaultValue(true);
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        builder.Property(x => x.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(x => x.RowGuid).IsUnique().HasDatabaseName("IX_PaymentMethods_RowGuid");
        builder.HasMany(x => x.UserPaymentMethods)
               .WithOne(x => x.PaymentMethod)
               .HasForeignKey(x => x.PaymentMethodId)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasData(
        new PaymentMethods
        {
            PaymentMethodId = 1,
            Name = "Efectivo",
            Description = "Metodo de pago en efectivo",
            CreatedBy = "Created By Default",
            IsDefault = true
        },
        new PaymentMethods 
        {
            PaymentMethodId = 2,
            Name = "Tarjeta de Credito",
            Description = "Metodo de pago en Tarjeta de Credito",
            CreatedBy = "Created By Default",
            IsDefault = true
        },
        new PaymentMethods
        {
            PaymentMethodId = 3,
            Name = "Tarjeta de Debito",
            Description = "Metodo de pago en Tarjeta de Debito",
            CreatedBy = "Created By Default",
            IsDefault = true
        });
    }
}
