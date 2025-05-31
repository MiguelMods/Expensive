using Expensive.Api.Requests;
using FluentValidation;

namespace Expensive.Api.Validations;

public class CategorieUpdateRequestValidator : AbstractValidator<CategorieUpdateRequest>
{
    public CategorieUpdateRequestValidator()
    {
        RuleFor(x => x.RowGuid).NotEmpty().WithMessage("RowGuid is required.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
    }
}
