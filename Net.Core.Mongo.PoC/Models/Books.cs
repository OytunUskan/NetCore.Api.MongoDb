using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net.Core.Mongo.PoC.Models
{
    public class Book : CoreModel
    {

        [BsonElement("ISBN")]
        [BsonRequired]
        public string ISBN { get; set; }

        [BsonElement("Name")]
        public string BookName { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("Author")]
        public Author Author { get; set; }


    }
}
