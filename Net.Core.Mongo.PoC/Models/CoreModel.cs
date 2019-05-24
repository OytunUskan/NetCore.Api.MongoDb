using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net.Core.Mongo.PoC.Models
{
    public abstract class CoreModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonRequired]
        [BsonDateTimeOptions]
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
