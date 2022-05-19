using AutoMapper;
using DevSocialMediaCaseProject.Application.Features.Commands.Posts;
using DevSocialMediaCaseProject.Application.Interfaces;
using DevSocialMediaCaseProject.Common.Constants;
using DevSocialMediaCaseProject.Common.Exceptions;
using DevSocialMediaCaseProject.Common.Wrappers;
using DevSocialMediaCaseProject.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.Application.Features.Queries.Posts.GetByUserIdPosts
{
    public class GetPostsByUserIdRequestHandler : IRequestHandler<GetPostsByUserIdRequest, ServiceDataResponse<IEnumerable<UserPostViewDTO>>>
    {
        private readonly IPostRepository _iPostRepository;
        public GetPostsByUserIdRequestHandler(IPostRepository repository)
        {
            _iPostRepository = repository;
        }

        public async Task<ServiceDataResponse<IEnumerable<UserPostViewDTO>>> Handle(GetPostsByUserIdRequest request, CancellationToken cancellationToken)
        {
            if (request.UserId != null)
            {
                var userPosts = await Task.Factory.StartNew(() => _iPostRepository.GetByUserIdPosts(request.UserId));

                return new ServiceDataResponse<IEnumerable<UserPostViewDTO>>(
                    userPosts, true);
            }
            throw new DatabaseException(ExceptionConstants.OBJECT_IS_NULL);
        }
    }
}
