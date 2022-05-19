using AutoMapper;
using DevSocialMediaCaseProject.Application.Features.Commands.Posts.CreatePost;
using DevSocialMediaCaseProject.Domain.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Application.Mappings
{
    public class PostMappings: Profile
    {
        public PostMappings()
        {
            //.ForMember(dest => new ObjectId(dest.UserId), opt => opt.MapFrom(src => src.UserId))
            CreateMap<Post, CreatePostRequest>().ReverseMap();
        }
    }
}
