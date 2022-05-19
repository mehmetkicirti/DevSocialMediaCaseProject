using AutoMapper;
using DevSocialMediaCaseProject.Application.Features.Commands.ValidationRules.FluentValidation.Posts;
using DevSocialMediaCaseProject.Application.Interfaces;
using DevSocialMediaCaseProject.Common.Aspects.Validation;
using DevSocialMediaCaseProject.Common.Constants;
using DevSocialMediaCaseProject.Common.Exceptions;
using DevSocialMediaCaseProject.Common.Utilities.Application;
using DevSocialMediaCaseProject.Common.Wrappers;
using DevSocialMediaCaseProject.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.Application.Features.Commands.Posts.UpdatePost
{
    public class UpdatePostRequestHandler : PostRequestHandler, IRequestHandler<UpdatePostRequest, ServiceResponse>
    {
        public UpdatePostRequestHandler(IUserRepository userRepository, IPostRepository repository, IMapper mapper) : base(userRepository, repository, mapper)
        {
        }
        [ValidationAspect(typeof(UpdatePostValidator))]
        public async Task<ServiceResponse> Handle(UpdatePostRequest request, CancellationToken cancellationToken)
        {
            if (ApplicationRules.RunLogicsAsync(IsPostExists(request.Id), IsUserExists(UserId)) == null)
            {
                var post = Mapper.Map<Post>(request);
                await Repository.UpdateAsync(post);
                return new ServiceResponse(ResponseConstants.UPDATE_ENTITY_SUCCESFULLY);
            }
            throw new DatabaseException(ExceptionConstants.RECORD_NOT_SAVED_ERROR);
        }
    }
}
