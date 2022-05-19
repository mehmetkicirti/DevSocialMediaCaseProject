using DevSocialMediaCaseProject.Application.Features.Commands.Posts.CreatePost;
using FluentValidation;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Features.Commands.ValidationRules.FluentValidation.Posts
{
    public class CreatePostValidator:AbstractValidator<CreatePostRequest>
    {
        public CreatePostValidator()
        {
            RuleFor(p => p.UserId).NotEmpty().Must(IsObjectId);
            RuleFor(p => p.Message).NotEmpty().MinimumLength(15).MaximumLength(9999);
        }

        private bool IsObjectId(string arg)
        {
            return ObjectId.TryParse(arg, out _);
        }
    }
}
