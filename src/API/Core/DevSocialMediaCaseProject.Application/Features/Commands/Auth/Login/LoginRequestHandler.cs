using AutoMapper;
using DevSocialMediaCaseProject.Application.Features.Commands.ValidationRules.FluentValidation.Users;
using DevSocialMediaCaseProject.Application.Interfaces;
using DevSocialMediaCaseProject.Common.Aspects.Validation;
using DevSocialMediaCaseProject.Common.Constants;
using DevSocialMediaCaseProject.Common.Domain.Concrete;
using DevSocialMediaCaseProject.Common.Exceptions;
using DevSocialMediaCaseProject.Common.Utilities.Security.Hashing;
using DevSocialMediaCaseProject.Common.Utilities.Security.JWT;
using DevSocialMediaCaseProject.Common.Wrappers;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.Application.Features.Commands.Auth.Login
{
    public class LoginRequestHandler : BaseRequestHandler<IUserRepository, User>,IRequestHandler<LoginRequest, ServiceDataResponse<string>>
    {
        private readonly ITokenHelper _iTokenHelper;
        public LoginRequestHandler(ITokenHelper tokenHelper, IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _iTokenHelper = tokenHelper;
        }

        [ValidationAspect(typeof(LoginUserValidator))]
        public async Task<ServiceDataResponse<string>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await Repository.GetByEmailAsync(request.Email);
            if(user == null)
            {
                throw new DatabaseException(ExceptionConstants.USER_NOT_EXIST_ERROR); 
            }
            if(!HashingHelper.Verify(request.Password, user.Password))
            {
                throw new DatabaseException(ExceptionConstants.PASSWORD_NOT_MATCHED_ERROR);
            }
            var accessToken = _iTokenHelper.CreateAccessToken(user);

            return new ServiceDataResponse<string>(JsonConvert.SerializeObject(accessToken.Token), ResponseConstants.LOGIN_SUCCESSFULLY);
        }
    }
}
