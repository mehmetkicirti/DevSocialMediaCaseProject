using DevSocialMediaCaseProject.Common.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Persistence.Contexts
{
    public interface IMongoDBContext
    {
        IMongoCollection<T> GetCollection<T>(string collectionName) 
            where T: BaseEntity;
    }
}
