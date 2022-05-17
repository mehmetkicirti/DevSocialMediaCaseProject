using DevSocialMediaCaseProject.Application.Interfaces;
using DevSocialMediaCaseProject.Domain.Models;
using DevSocialMediaCaseProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Persistence.Repositories.Concretes
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(IMongoDBContext context) : base(context)
        {
        }
    }
}
