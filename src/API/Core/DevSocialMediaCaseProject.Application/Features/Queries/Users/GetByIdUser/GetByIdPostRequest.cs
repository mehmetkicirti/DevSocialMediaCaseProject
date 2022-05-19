using DevSocialMediaCaseProject.Application.Features.ViewModels.Posts;
using DevSocialMediaCaseProject.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Features.Queries.Users.GetByIdUser
{
    public class GetByIdPostRequest: IRequest<ServiceDataResponse<PostViewModel>>
    {
        public string Id { get; set; }
    }
}
