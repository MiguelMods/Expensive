using Expensive.Api.Requests;
using FluentValidation;

namespace Expensive.Api.Validations;
public class CategorieAddRequestValidator : AbstractValidator<CategorieAddRequest>
{
    public CategorieAddRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
        RuleFor(x => x.Operation)
            .NotEmpty().WithMessage("Operation is required.")
            .MaximumLength(50).WithMessage("Operation must not exceed 50 characters.");
    }
}