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
    public class DeletePostRequestHandler : BaseRequestHandler<IPostRepository, Post>, IRequestHandler<DeletePostRequest, ServiceResponse>
    {
        private readonly IUserRepository _iUserRepository;
        private const int BadRequestCode = (int)HttpStatusCode.BadRequest;
        private string UserId;
        public DeletePostRequestHandler(IUserRepository userRepository, IPostRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _iUserRepository = userRepository;
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

        #region Logics
        private async Task<IResponse> IsPostExists(string postId)
        {
            if (CheckObjectIdIsNotNull(postId))
            {
                var post = await Repository.GetByIdAsync(postId);
                if (post == null)
                {
                    return new ErrorResponse(ResponseConstants.ENTITY_NOT_EXIST, BadRequestCode);
                }
                UserId = post.UserId.ToString();
                return new ServiceResponse();
            }
            return new ErrorResponse(ResponseConstants.OBJECT_ID_IS_NULL, BadRequestCode);
        }

        private async Task<IResponse> IsUserExists(string userId)
        {
            if (CheckObjectIdIsNotNull(userId))
            {
                var user = await _iUserRepository.GetByIdAsync(userId);
                if (user == null)
                {
                    return new ErrorResponse(ResponseConstants.ENTITY_NOT_EXIST, BadRequestCode);
                }
                return new ServiceResponse();
            }
            return new ErrorResponse(ResponseConstants.OBJECT_ID_IS_NULL, BadRequestCode);
        }

        private bool CheckObjectIdIsNotNull(string id) => id != null ? true : false;
        #endregion
    }
}
