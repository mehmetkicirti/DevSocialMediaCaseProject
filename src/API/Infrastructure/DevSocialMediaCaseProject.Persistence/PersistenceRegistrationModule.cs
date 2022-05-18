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
    public class PersistenceRegistrationModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IMongoDBContext>().As<MongoDBContext>();

            #region RepositoryRegistration
            builder.RegisterType<IUserRepository>().As<UserRepository>();
            builder.RegisterType<IPostRepository>().As<PostRepository>();
            #endregion
        }
    }
}
