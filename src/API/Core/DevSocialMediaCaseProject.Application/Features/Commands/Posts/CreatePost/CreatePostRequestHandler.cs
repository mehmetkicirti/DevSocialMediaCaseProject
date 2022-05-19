using AutoMapper;
using DevSocialMediaCaseProject.Application.Features.Commands.ValidationRules.FluentValidation.Posts;
using DevSocialMediaCaseProject.Application.Interfaces;
using DevSocialMediaCaseProject.Common.Aspects.Validation;
using DevSocialMediaCaseProject.Common.Constants;
using DevSocialMediaCaseProject.Common.Wrappers;
using DevSocialMediaCaseProject.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.Application.Features.Commands.Posts.CreatePost
{
    public class CreatePostRequestHandler : BaseRequestHandler<IPostRepository, Post>,IRequestHandler<CreatePostRequest, ServiceResponse>
    {
        public CreatePostRequestHandler(IPostRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        [ValidationAspect(typeof(CreatePostValidator))]
        public async Task<ServiceResponse> Handle(CreatePostRequest request, CancellationToken cancellationToken)
        {
            var post = Mapper.Map<Post>(request);
            await Repository.AddAsync(post);

            return new ServiceResponse(ResponseConstants.CREATE_ENTITY_SUCCESSFULLY);
        }
    }
}
