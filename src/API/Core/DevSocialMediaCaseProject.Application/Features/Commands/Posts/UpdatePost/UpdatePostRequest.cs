using DevSocialMediaCaseProject.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Features.Commands.Posts.UpdatePost
{
    public class UpdatePostRequest: IRequest<ServiceResponse>
    {
        public string Id { get; set; }
        public string Message { get; set; }
    }
}
