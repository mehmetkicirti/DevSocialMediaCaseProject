using AutoMapper;
using DevSocialMediaCaseProject.Application.Features.Commands.Auth.Login;
using DevSocialMediaCaseProject.Application.Features.Commands.Auth.Register;
using DevSocialMediaCaseProject.Common.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Mappings
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<User, RegisterRequest>().ReverseMap();
            CreateMap<User, LoginRequest>().ReverseMap();
        }
    }
}
