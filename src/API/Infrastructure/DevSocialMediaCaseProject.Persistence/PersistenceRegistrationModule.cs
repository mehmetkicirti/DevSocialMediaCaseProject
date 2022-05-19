using Autofac;
using Autofac.Configuration;
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
    public static class PersistenceRegistrationModule
    {
        public static void AddPersistenceServiceRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IMongoDBContext, MongoDBContext>();
            #region RepositoryRegistration
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IPostRepository, PostRepository>();
            #endregion


        }
        //protected override void Load(ContainerBuilder builder)
        //{
        //    builder.RegisterType<IMongoDBContext>().As<MongoDBContext>().SingleInstance();

        //    #region RepositoryRegistration
        //    builder.RegisterType<IUserRepository>().As<UserRepository>().SingleInstance();
        //    builder.RegisterType<IPostRepository>().As<PostRepository>().SingleInstance();
        //    #endregion
        //}
    }
}
