using DevSocialMediaCaseProject.Application.Features.ViewModels.Posts;
using DevSocialMediaCaseProject.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Features.Queries.Posts.GetAllPosts
{
    public class GetAllPostsRequest: IRequest<ServiceDataResponse<IEnumerable<PostViewModel>>>
    {
    }
}
