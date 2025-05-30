using Expensive.Api.Requests;
using FluentValidation;

namespace Expensive.Api.Validations
{
    public class LoginRegisterRequestValidator : AbstractValidator<LoginRegisterRequest>
    {
        public LoginRegisterRequestValidator()
        {
            RuleFor(x => x.FirtName)
                .NotEmpty()
                .WithMessage("First name is required.");
            RuleFor(x => x.LastName).NotEmpty()
                .WithMessage("Last name is required.");
            RuleFor(x => x.UserName).NotEmpty()
                .WithMessage("User name is required.");
            RuleFor(x => x.Email).NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.");
            RuleFor(x => x.Password).NotEmpty().NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long.");
        }
    }
}
