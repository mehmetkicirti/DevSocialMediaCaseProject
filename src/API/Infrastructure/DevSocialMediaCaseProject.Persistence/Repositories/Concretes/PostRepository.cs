using DevSocialMediaCaseProject.Application.Interfaces;
using DevSocialMediaCaseProject.Common.Domain.Concrete;
using DevSocialMediaCaseProject.Domain.DTOs;
using DevSocialMediaCaseProject.Domain.Models;
using DevSocialMediaCaseProject.Persistence.Contexts;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.Persistence.Repositories.Concretes
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(IMongoDBContext context) : base(context)
        {
        }

        public IEnumerable<UserPostViewDTO> GetByUserIdPosts(string userId)
        {
            var users = _mongoContext.GetCollection<User>(typeof(User).Name).AsQueryable<User>();
            var posts = _dbCollection.AsQueryable<Post>();

            var query = from u in users
                        join p in posts on u.Id equals ObjectId.Parse(userId)
                        into joinedUserPosts
                        select new UserPostViewDTO
                        {
                            Email = u.Email,
                            Id = u.Id,
                            Name = u.Name,
                            Surname = u.Surname,
                            Posts = joinedUserPosts
                        };
            return query.ToList();

        }
    }
}
