using Expensive.Application.Response;
using Expensive.Domain.Entities;

namespace Expensive.Application.Models.dto;

public class PaymentMethodDTO : BaseResponse
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public static explicit operator PaymentMethodDTO(PaymentMethods paymentMethod)
    {
        return new PaymentMethodDTO
        {
            Id = paymentMethod.PaymentMethodId,
            Name = paymentMethod.Name,
            Description = paymentMethod.Description,
            CreatedAt = paymentMethod.CreatedAt,
            CreatedBy = paymentMethod.CreatedBy,
            UpdatedAt = paymentMethod.UpdatedAt,
            UpdatedBy = paymentMethod.UpdatedBy,
            IsActive = paymentMethod.IsActive,
            IsDeleted = paymentMethod.IsDeleted,
            RowGuid = paymentMethod.RowGuid
        };
    }
}
