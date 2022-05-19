using DevSocialMediaCaseProject.Common.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevSocialMediaCaseProject.Application.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
