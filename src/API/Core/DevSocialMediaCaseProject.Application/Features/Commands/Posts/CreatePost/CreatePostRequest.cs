using DevSocialMediaCaseProject.Common.Wrappers;
using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Features.Commands.Posts.CreatePost
{
    public class CreatePostRequest: IRequest<ServiceResponse>
    {
        public string UserId { get; set; }
        public string Message { get; set; }
    }
}
