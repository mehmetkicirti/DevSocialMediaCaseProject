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

namespace DevSocialMediaCaseProject.Application.Features.Commands.Users.DeleteUser
{
    public class DeleteUserRequestHandler : BaseRequestHandler<IUserRepository, User>,IRequestHandler<DeleteUserRequest, ServiceResponse>
    {
        public DeleteUserRequestHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<ServiceResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            await Repository.DeleteAsync(request.Id);
            return new ServiceResponse(ResponseConstants.DELETE_ENTITY_SUCCESFULLY);
        }
    }
}
