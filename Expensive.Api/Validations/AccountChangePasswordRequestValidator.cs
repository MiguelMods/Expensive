using Expensive.Api.Requests;
using FluentValidation;

namespace Expensive.Api.Validations
{
    public class AccountChangePasswordRequestValidator : AbstractValidator<AccountChangePasswordRequest>
    {
        public AccountChangePasswordRequestValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(100).WithMessage("Username must not exceed 100 characters.");
            RuleFor(x => x.OldPassword).NotEmpty().WithMessage("Old password is required.")
                .MinimumLength(8).WithMessage("Old password must be at least 8 characters long.");
            RuleFor(x => x.NewPassord).NotEmpty().WithMessage("New password is required.")
                .MinimumLength(8).WithMessage("Old password must be at least 8 characters long.");
            RuleFor(x => x.NewPassord).NotEqual(x => x.OldPassword).WithMessage("new Password must be different of old password");
        }
    }
}
