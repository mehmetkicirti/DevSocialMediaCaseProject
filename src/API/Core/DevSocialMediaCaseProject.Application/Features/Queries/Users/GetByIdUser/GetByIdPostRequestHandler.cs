using AutoMapper;
using DevSocialMediaCaseProject.Application.Features.ViewModels.Posts;
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

namespace DevSocialMediaCaseProject.Application.Features.Queries.Users.GetByIdUser
{
    public class GetByIdPostRequestHandler : BaseRequestHandler<IUserRepository, User>, IRequestHandler<GetByIdPostRequest, ServiceDataResponse<PostViewModel>>
    {
        public GetByIdPostRequestHandler(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<ServiceDataResponse<PostViewModel>> Handle(GetByIdPostRequest request, CancellationToken cancellationToken)
        {
            var post = await Repository.GetByIdAsync(request.Id);
            if (post == null)
            {
                throw new DatabaseException(ResponseConstants.ENTITY_NOT_EXIST);
            }
            var viewModel = Mapper.Map<PostViewModel>(post);
            return new ServiceDataResponse<PostViewModel>(viewModel, true);
        }
    }
}
