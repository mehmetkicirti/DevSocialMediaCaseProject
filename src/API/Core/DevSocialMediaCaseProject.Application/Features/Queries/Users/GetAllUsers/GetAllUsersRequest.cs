using DevSocialMediaCaseProject.Application.Features.ViewModels.Users;
using DevSocialMediaCaseProject.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Features.Queries.Users.GetAllUsers
{
    public class GetAllUsersRequest:IRequest<ServiceDataResponse<IEnumerable<UserViewModel>>>
    {
    }
}
