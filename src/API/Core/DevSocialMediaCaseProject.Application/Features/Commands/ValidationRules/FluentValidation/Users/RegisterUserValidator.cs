using DevSocialMediaCaseProject.Application.Features.Commands.Auth.Register;
using DevSocialMediaCaseProject.Common.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Features.Commands.ValidationRules.FluentValidation.Users
{
    public class RegisterUserValidator: AbstractValidator<RegisterRequest>
    {
        public RegisterUserValidator()
        {
            RuleFor(u => u.Name).NotEmpty().MinimumLength(2).MaximumLength(75);
            RuleFor(u => u.Surname).NotEmpty().MinimumLength(2).MaximumLength(75);
            RuleFor(u => u.Password).NotEmpty().MinimumLength(8).MaximumLength(16)
                .Matches("[A-Z]").WithMessage(ErrorValidationConstants.PASSWORD_UPPERCASE_LETTER)
                .Matches("[a-z]").WithMessage(ErrorValidationConstants.PASSWORD_LOWERCASE_LETTER)
                .Matches("[0-9]").WithMessage(ErrorValidationConstants.PASSWORD_DIGIT)
                .Matches("[^a-zA-Z0-9]").WithMessage(ErrorValidationConstants.PASSWORD_SPECIAL_CHARACTER);
            RuleFor(u => u.Email).NotEmpty().EmailAddress();
        }
    }
}
