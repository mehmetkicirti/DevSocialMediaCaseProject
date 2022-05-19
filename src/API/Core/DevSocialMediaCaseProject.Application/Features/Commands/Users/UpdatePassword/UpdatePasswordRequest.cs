using DevSocialMediaCaseProject.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Features.Commands.Users.UpdatePassword
{
    public class UpdatePasswordRequest: IRequest<ServiceResponse>
    {
        public string Id { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}
