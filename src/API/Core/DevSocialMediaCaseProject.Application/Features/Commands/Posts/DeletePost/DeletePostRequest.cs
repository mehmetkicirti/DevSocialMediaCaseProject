using DevSocialMediaCaseProject.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Features.Commands.Posts.DeletePost
{
    public class DeletePostRequest: IRequest<ServiceResponse>
    {
        public string Id { get; set; }
    }
}
