using DevSocialMediaCaseProject.Common.Configurations.MongoDB;
using DevSocialMediaCaseProject.Common.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Persistence.Contexts.MongoDB
{
    public class MongoDBContext : IMongoDBContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public MongoDBContext(IOptions<MongoDBSetting> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.ConnectionURL);
            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName) where T : BaseEntity => _db.GetCollection<T>(collectionName);
    }
}
