using DevSocialMediaCaseProject.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Features.Commands.Users.DeleteUser
{
    public class DeleteUserRequest: IRequest<ServiceResponse>
    {
        public string Id { get; set; }
    }
}
