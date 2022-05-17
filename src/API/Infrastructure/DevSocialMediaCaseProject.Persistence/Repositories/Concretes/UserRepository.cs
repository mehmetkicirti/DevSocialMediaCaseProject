using DevSocialMediaCaseProject.Application.Interfaces;
using DevSocialMediaCaseProject.Domain.Models;
using DevSocialMediaCaseProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Persistence.Repositories.Concretes
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoDBContext context) : base(context)
        {
        }
    }
}
