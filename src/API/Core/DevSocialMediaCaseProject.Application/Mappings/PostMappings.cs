using AutoMapper;
using DevSocialMediaCaseProject.Application.Features.Commands.Posts.CreatePost;
using DevSocialMediaCaseProject.Application.Features.Commands.Posts.DeletePost;
using DevSocialMediaCaseProject.Application.Features.Commands.Posts.UpdatePost;
using DevSocialMediaCaseProject.Application.Features.ViewModels.Posts;
using DevSocialMediaCaseProject.Domain.DTOs;
using DevSocialMediaCaseProject.Domain.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Mappings
{
    public class PostMappings: Profile
    {
        public PostMappings()
        {
            //.ForMember(dest => new ObjectId(dest.UserId), opt => opt.MapFrom(src => src.UserId))
            CreateMap<Post, CreatePostRequest>().ReverseMap();
            CreateMap<Post, DeletePostRequest>().ReverseMap();
            CreateMap<Post, UpdatePostRequest>().ReverseMap();
            CreateMap<Post, PostViewModel>().ReverseMap();
        }
    }
}
