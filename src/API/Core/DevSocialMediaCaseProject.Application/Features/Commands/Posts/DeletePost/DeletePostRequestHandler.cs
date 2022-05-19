using AutoMapper;
using DevSocialMediaCaseProject.Application.Interfaces;
using DevSocialMediaCaseProject.Common.Constants;
using DevSocialMediaCaseProject.Common.Exceptions;
using DevSocialMediaCaseProject.Common.Utilities.Application;
using DevSocialMediaCaseProject.Common.Wrappers;
using DevSocialMediaCaseProject.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.Application.Features.Commands.Posts.DeletePost
{
    public class DeletePostRequestHandler : PostRequestHandler, IRequestHandler<DeletePostRequest, ServiceResponse>
    {
        public DeletePostRequestHandler(IUserRepository userRepository, IPostRepository repository, IMapper mapper) : base(userRepository, repository, mapper)
        {
        }

        public async Task<ServiceResponse> Handle(DeletePostRequest request, CancellationToken cancellationToken)
        {
            if (ApplicationRules.RunLogicsAsync(IsPostExists(request.Id), IsUserExists(UserId)) == null)
            {
                await Repository.DeleteAsync(request.Id);
                return new ServiceResponse(ResponseConstants.DELETE_ENTITY_SUCCESFULLY);
            }

            throw new DatabaseException(ResponseConstants.DELETE_ENTITY_FAILED, BadRequestCode);
        }
    }
}
