using AutoMapper;
using DevSocialMediaCaseProject.Application.Interfaces;
using DevSocialMediaCaseProject.Common.Constants;
using DevSocialMediaCaseProject.Common.Wrappers;
using DevSocialMediaCaseProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.Application.Features.Commands.Posts
{
    public abstract class PostRequestHandler : BaseRequestHandler<IPostRepository, Post>
    {
        protected readonly IUserRepository UserRepository;
        public const int BadRequestCode = (int)HttpStatusCode.BadRequest;
        protected string UserId;
        protected PostRequestHandler(IUserRepository userRepository,IPostRepository repository, IMapper mapper) : base(repository, mapper)
        {
            UserRepository = userRepository;
        }

        protected PostRequestHandler(IPostRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        #region Logics
        protected async Task<IResponse> IsPostExists(string postId)
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

        protected async Task<IResponse> IsUserExists(string userId)
        {
            if (CheckObjectIdIsNotNull(userId))
            {
                var user = await UserRepository.GetByIdAsync(userId);
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
