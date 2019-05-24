using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net.Core.Mongo.PoC.Models
{
    public class Author : CoreModel
    {
        [BsonElement("AuthorId")]
        public int AuthorId { get; set; }
        [BsonElement("FullName")]
        public string Name { get; set; }
        [BsonElement("Age")]
        public int Age { get; set; }
    }
}
