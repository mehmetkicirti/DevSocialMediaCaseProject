using DevSocialMediaCaseProject.Application.Features.ViewModels.Users;
using DevSocialMediaCaseProject.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Features.Queries.Posts.GetByIdPost
{
    public class GetByIdUserRequest:IRequest<ServiceDataResponse<UserViewModel>>
    {
        public string Id { get; set; }
    }
}
