using AutoMapper;
using DevSocialMediaCaseProject.Application.Features.Commands.ValidationRules.FluentValidation.Users;
using DevSocialMediaCaseProject.Application.Interfaces;
using DevSocialMediaCaseProject.Common.Aspects.Validation;
using DevSocialMediaCaseProject.Common.Constants;
using DevSocialMediaCaseProject.Common.Domain.Concrete;
using DevSocialMediaCaseProject.Common.Exceptions;
using DevSocialMediaCaseProject.Common.Utilities.Application;
using DevSocialMediaCaseProject.Common.Utilities.Security.Hashing;
using DevSocialMediaCaseProject.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.Application.Features.Commands.Users.UpdatePassword
{
    public class UpdatePasswordRequestHandler : BaseRequestHandler<IUserRepository, User>, IRequestHandler<UpdatePasswordRequest, ServiceResponse>
    {
        public UpdatePasswordRequestHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        [ValidationAspect(typeof(UpdateUserPasswordValidator))]
        public async Task<ServiceResponse> Handle(UpdatePasswordRequest request, CancellationToken cancellationToken)
        {
            if (ApplicationRules.RunLogicsAsync(IsUserExists(request.Id), CheckSimilarPassword(request.OldPassword, request.NewPassword)) == null)
            {
                var hashedNewPassword = HashingHelper.Hash(request.NewPassword);
                request.NewPassword = hashedNewPassword;
                var user = Mapper.Map<User>(request);
                await Repository.UpdateAsync(user);
                return new ServiceResponse(ResponseConstants.UPDATE_ENTITY_SUCCESFULLY);
            }
            throw new DatabaseException(ExceptionConstants.RECORD_NOT_SAVED_ERROR);
        }

        #region Logics
        private async Task<IResponse> IsUserExists(string id)
        {
            var user = await Repository.GetByIdAsync(id);
            if (user == null)
            {
                throw new DatabaseException(ExceptionConstants.USER_NOT_EXIST_ERROR);
            }
            return new ServiceResponse();
        }
        private async Task<IResponse> CheckSimilarPassword(string oldPassword, string newPassword)
        {
            bool IsSimilar = await Task.Factory.StartNew(() => oldPassword.ToLowerInvariant() == newPassword.ToLowerInvariant());
            if (IsSimilar)
            {
                throw new DatabaseException(ExceptionConstants.PASSWORD_SIMILAR_ERROR);
            }
            return new ServiceResponse();
        }

        #endregion
    }
}
