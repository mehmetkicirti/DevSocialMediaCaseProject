using DevSocialMediaCaseProject.Common.Domain;
using DevSocialMediaCaseProject.Domain.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Domain.DTOs
{
    public class UserPostViewDTO: IDto
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
