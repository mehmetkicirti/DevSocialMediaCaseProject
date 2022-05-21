using AutoMapper;
using DevSocialMediaCaseProject.Application.Features.Commands.Posts;
using DevSocialMediaCaseProject.Application.Features.ViewModels.Posts;
using DevSocialMediaCaseProject.Application.Interfaces;
using DevSocialMediaCaseProject.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.Application.Features.Queries.Posts.GetAllPosts
{
    public class GetAllPostsRequestHandler : PostRequestHandler, IRequestHandler<GetAllPostsRequest, ServiceDataResponse<IEnumerable<PostViewModel>>>
    {
        public GetAllPostsRequestHandler(IPostRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<ServiceDataResponse<IEnumerable<PostViewModel>>> Handle(GetAllPostsRequest request, CancellationToken cancellationToken)
        {
            var posts = await Repository.GetAllAsync();
            await Task.Delay(1500);
            var viewModel = Mapper.Map<IEnumerable<PostViewModel>>(posts);
            return new ServiceDataResponse<IEnumerable<PostViewModel>>(viewModel, true);
        }
    }
}
