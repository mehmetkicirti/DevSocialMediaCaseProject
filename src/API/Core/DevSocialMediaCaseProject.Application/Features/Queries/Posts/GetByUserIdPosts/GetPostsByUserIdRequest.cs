using DevSocialMediaCaseProject.Common.Wrappers;
using DevSocialMediaCaseProject.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Features.Queries.Posts.GetByUserIdPosts
{
    public class GetPostsByUserIdRequest: IRequest<ServiceDataResponse<IEnumerable<UserPostViewDTO>>>
    {
        public string UserId { get; set; }
    }
}
