﻿using Expensive.Api.Requests;
using FluentValidation;

namespace Expensive.Api.Validations
{
    public class LoginUsernamePasswordRequestValidator : AbstractValidator<LoginUsernamePasswordRequest>
    {
        public LoginUsernamePasswordRequestValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Username is required.");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.");
        }
    }
}
