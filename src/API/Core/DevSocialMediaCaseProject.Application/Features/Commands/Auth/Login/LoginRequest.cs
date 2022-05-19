using DevSocialMediaCaseProject.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Features.Commands.Auth.Login
{
    public class LoginRequest: IRequest<ServiceDataResponse<string>>
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
