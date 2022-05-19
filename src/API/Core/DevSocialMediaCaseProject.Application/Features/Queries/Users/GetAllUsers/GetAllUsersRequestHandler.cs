using AutoMapper;
using DevSocialMediaCaseProject.Application.Features.ViewModels.Users;
using DevSocialMediaCaseProject.Application.Interfaces;
using DevSocialMediaCaseProject.Common.Domain.Concrete;
using DevSocialMediaCaseProject.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.Application.Features.Queries.Users.GetAllUsers
{
    public class GetAllUsersRequestHandler : BaseRequestHandler<IUserRepository, User>, IRequestHandler<GetAllUsersRequest, ServiceDataResponse<IEnumerable<UserViewModel>>>
    {
        public GetAllUsersRequestHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<ServiceDataResponse<IEnumerable<UserViewModel>>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var users = await Repository.GetAllAsync();
            var viewModel = Mapper.Map<IEnumerable<UserViewModel>>(users);
            return new ServiceDataResponse<IEnumerable<UserViewModel>>(viewModel, true);
        }
    }
}
