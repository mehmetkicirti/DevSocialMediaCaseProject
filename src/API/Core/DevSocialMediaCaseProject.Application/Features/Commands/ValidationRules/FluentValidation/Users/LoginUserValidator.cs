using DevSocialMediaCaseProject.Application.Features.Commands.Auth.Login;
using DevSocialMediaCaseProject.Common.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Features.Commands.ValidationRules.FluentValidation.Users
{
    public class LoginUserValidator : AbstractValidator<LoginRequest>
    {
        public LoginUserValidator()
        {
            RuleFor(u => u.Password).NotEmpty().MinimumLength(8).MaximumLength(16)
                .Matches("[A-Z]").WithMessage(ErrorValidationConstants.PASSWORD_UPPERCASE_LETTER)
                .Matches("[a-z]").WithMessage(ErrorValidationConstants.PASSWORD_LOWERCASE_LETTER)
                .Matches("[0-9]").WithMessage(ErrorValidationConstants.PASSWORD_DIGIT)
                .Matches("[^a-zA-Z0-9]").WithMessage(ErrorValidationConstants.PASSWORD_SPECIAL_CHARACTER);
            RuleFor(u => u.Email).NotEmpty().EmailAddress();
        }
    }
}
