using DevSocialMediaCaseProject.Application.Features.Commands.Posts.UpdatePost;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Features.Commands.ValidationRules.FluentValidation.Posts
{
    public class UpdatePostValidator : AbstractValidator<UpdatePostRequest>
    {
        public UpdatePostValidator()
        {
            RuleFor(p => p.Message).NotEmpty().MinimumLength(15).MaximumLength(9999);
        }
    }
}
