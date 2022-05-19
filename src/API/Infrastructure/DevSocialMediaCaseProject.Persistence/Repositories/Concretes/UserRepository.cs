using DevSocialMediaCaseProject.Application.Interfaces;
using DevSocialMediaCaseProject.Common.Domain.Concrete;
using DevSocialMediaCaseProject.Persistence.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.Persistence.Repositories.Concretes
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoDBContext context) : base(context)
        {
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("Email", email);
            return await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }
    }
}
