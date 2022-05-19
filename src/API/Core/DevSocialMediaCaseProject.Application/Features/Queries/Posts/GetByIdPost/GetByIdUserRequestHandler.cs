using AutoMapper;
using DevSocialMediaCaseProject.Application.Features.ViewModels.Users;
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

namespace DevSocialMediaCaseProject.Application.Features.Queries.Posts.GetByIdPost
{
    public class GetByIdUserRequestHandler : BaseRequestHandler<IUserRepository, User>,IRequestHandler<GetByIdUserRequest, ServiceDataResponse<UserViewModel>>
    {
        public GetByIdUserRequestHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<ServiceDataResponse<UserViewModel>> Handle(GetByIdUserRequest request, CancellationToken cancellationToken)
        {
            var user = await Repository.GetByIdAsync(request.Id);
            if(user == null)
            {
                throw new DatabaseException(ResponseConstants.ENTITY_NOT_EXIST);
            }
            var viewModel = Mapper.Map<UserViewModel>(user);
            return new ServiceDataResponse<UserViewModel>(viewModel, true);
        }
    }
}
