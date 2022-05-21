using AutoMapper;
using DevSocialMediaCaseProject.Application.Features.Commands.Posts;
using DevSocialMediaCaseProject.Application.Interfaces;
using DevSocialMediaCaseProject.Common.Wrappers;
using DevSocialMediaCaseProject.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.Application.Features.Queries.Posts.GetAllPostDetails
{
    public class GetAllPostDetailsRequestHandler : PostRequestHandler, IRequestHandler<GetAllPostDetailsRequest, ServiceDataResponse<IEnumerable<UserPostViewDTO>>>
    {
        public GetAllPostDetailsRequestHandler(IPostRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<ServiceDataResponse<IEnumerable<UserPostViewDTO>>> Handle(GetAllPostDetailsRequest request, CancellationToken cancellationToken)
        {
            var userPosts = await Task.Factory.StartNew(() => Repository.GetAllPostDetails());

            return new ServiceDataResponse<IEnumerable<UserPostViewDTO>>(
                userPosts, true);
        }
    }
}
