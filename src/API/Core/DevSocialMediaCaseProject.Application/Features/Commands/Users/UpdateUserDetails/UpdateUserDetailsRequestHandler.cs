using AutoMapper;
using DevSocialMediaCaseProject.Application.Interfaces;
using DevSocialMediaCaseProject.Common.Constants;
using DevSocialMediaCaseProject.Common.Domain.Concrete;
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
            var user = Mapper.Map<User>(request);
            await Repository.UpdateAsync(user);
            return new ServiceResponse(ResponseConstants.UPDATE_ENTITY_SUCCESFULLY);
        }
    }
}
