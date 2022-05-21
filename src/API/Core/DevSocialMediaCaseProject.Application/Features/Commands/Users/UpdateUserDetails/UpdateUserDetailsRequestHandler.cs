using AutoMapper;
using DevSocialMediaCaseProject.Application.Interfaces;
using DevSocialMediaCaseProject.Common.Constants;
using DevSocialMediaCaseProject.Common.Domain.Concrete;
using DevSocialMediaCaseProject.Common.Exceptions;
using DevSocialMediaCaseProject.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.Application.Features.Commands.Users.UpdateUserDetails
{
    public class UpdateUserDetailsRequestHandler : BaseRequestHandler<IUserRepository, User>, IRequestHandler<UpdateUserDetailsRequest, ServiceResponse>
    {
        public UpdateUserDetailsRequestHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<ServiceResponse> Handle(UpdateUserDetailsRequest request, CancellationToken cancellationToken)
        {
            var newUser = Mapper.Map<User>(request);
            var user = await Repository.GetByIdAsync(request.Id);
            if(user != null)
            {
                newUser.Password = user.Password;
                await Repository.UpdateAsync(newUser);
                return new ServiceResponse(ResponseConstants.UPDATE_ENTITY_SUCCESFULLY);
            }
            throw new DatabaseException(ExceptionConstants.USER_NOT_EXIST_ERROR);
        }
    }
}
