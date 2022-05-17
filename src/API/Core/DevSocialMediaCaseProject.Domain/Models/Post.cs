using DevSocialMediaCaseProject.Common.Domain;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Domain.Models
{
    public class Post: BaseEntity
    {
        public ObjectId UserId { get; set; }
        public string Message { get; set; }
    }
}
