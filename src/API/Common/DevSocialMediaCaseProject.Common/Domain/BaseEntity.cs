using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSocialMediaCaseProject.Common.Domain
{
    public abstract class BaseEntity
    {
        public ObjectId Id { get; set; }        
    }
}
