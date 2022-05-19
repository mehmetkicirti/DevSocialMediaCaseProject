using AutoMapper;
using DevSocialMediaCaseProject.Application.Features.Commands.Auth.Login;
using DevSocialMediaCaseProject.Application.Features.Commands.Auth.Register;
using DevSocialMediaCaseProject.Application.Features.Commands.Users.DeleteUser;
using DevSocialMediaCaseProject.Application.Features.Commands.Users.UpdatePassword;
using DevSocialMediaCaseProject.Application.Features.Commands.Users.UpdateUserDetails;
using DevSocialMediaCaseProject.Application.Features.ViewModels.Users;
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
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<User, DeleteUserRequest>().ReverseMap();
            CreateMap<User, UpdatePasswordRequest>().ForMember(dest => dest.NewPassword, opt=> opt.MapFrom(mem=>mem.Password)).ReverseMap();
            CreateMap<User, UpdateUserDetailsRequest>().ReverseMap();
        }
    }
}
