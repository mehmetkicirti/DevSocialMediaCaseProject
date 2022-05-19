using DevSocialMediaCaseProject.Application.Features.Commands.Users.UpdatePassword;
using DevSocialMediaCaseProject.Common.Constants;
using FluentValidation;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Features.Commands.ValidationRules.FluentValidation.Users
{
    public class UpdateUserPasswordValidator : AbstractValidator<UpdatePasswordRequest>
    {
        public UpdateUserPasswordValidator()
        {
            RuleFor(u => u.Id).NotEmpty().Must(IsObjectId);
            RuleFor(u => u.OldPassword).NotEmpty().MinimumLength(8).MaximumLength(16);
            RuleFor(u => u.NewPassword).NotEmpty().MinimumLength(8).MaximumLength(16)
                .Matches("[A-Z]").WithMessage(ErrorValidationConstants.PASSWORD_UPPERCASE_LETTER)
                .Matches("[a-z]").WithMessage(ErrorValidationConstants.PASSWORD_LOWERCASE_LETTER)
                .Matches("[0-9]").WithMessage(ErrorValidationConstants.PASSWORD_DIGIT)
                .Matches("[^a-zA-Z0-9]").WithMessage(ErrorValidationConstants.PASSWORD_SPECIAL_CHARACTER);
        }

        private bool IsObjectId(string arg)
        {
            return ObjectId.TryParse(arg, out _);
        }
    }
}
