using DevSocialMediaCaseProject.Domain.DTOs;
using DevSocialMediaCaseProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.Application.Interfaces
{
    public interface IPostRepository: IRepository<Post>
    {
        IEnumerable<UserPostViewDTO> GetByUserIdPosts(string userId);
        IEnumerable<UserPostViewDTO> GetAllPostDetails();
    }
}
