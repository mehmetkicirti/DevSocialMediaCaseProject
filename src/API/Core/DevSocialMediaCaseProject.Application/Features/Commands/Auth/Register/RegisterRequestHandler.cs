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

namespace DevSocialMediaCaseProject.Application.Features.Commands.Auth.Register
{
    public class RegisterRequestHandler : BaseRequestHandler<IUserRepository, User>,IRequestHandler<RegisterRequest, ServiceResponse>
    {
        public RegisterRequestHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
        [ValidationAspect(typeof(RegisterUserValidator))]
        public async Task<ServiceResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            // Register User if logics is true
            if (ApplicationRules.RunLogicsAsync(UserExists(request.Email)) == null)
            {
                // Hashing the password
                var hashedPassword = HashingHelper.Hash(request.Password);
                request.Password = hashedPassword;

                var user = Mapper.Map<User>(request);
                await Repository.AddAsync(user);

                return new ServiceResponse(ResponseConstants.REGISTER_SUCCESSFULLY);
            }
            throw new DatabaseException(ResponseConstants.CREATE_ENTITY_FAILED);
        }


        public async Task<IResponse> UserExists(string email)
        {
            if (await Repository.GetByEmailAsync(email) != null)
            {
                throw new DatabaseException(ExceptionConstants.USER_EXIST_ERROR);
            }
            return new ServiceResponse();
        }
    }
}
