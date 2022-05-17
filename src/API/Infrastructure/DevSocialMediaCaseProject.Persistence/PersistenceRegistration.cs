using DevSocialMediaCaseProject.Application.Interfaces;
using DevSocialMediaCaseProject.Common.Configurations.MongoDB;
using DevSocialMediaCaseProject.Persistence.Contexts;
using DevSocialMediaCaseProject.Persistence.Contexts.MongoDB;
using DevSocialMediaCaseProject.Persistence.Repositories.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Persistence
{
    public static class PersistenceRegistration
    {
        public static void PersistenceServicesRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDBSetting>(opt =>
            {
                opt.ConnectionURL = configuration.GetSection("MongoDBConnection:ConnectionURL").Value;
                opt.DatabaseName = configuration.GetSection("MongoDBConnection:DatabaseName").Value;
            });
            services.AddScoped<IMongoDBContext, MongoDBContext>();
            #region RepositoryRegistration
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            #endregion
        }
    }
}
