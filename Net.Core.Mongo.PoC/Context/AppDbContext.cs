using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Net.Core.Mongo.PoC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net.Core.Mongo.PoC.Context
{
    public class AppDbContext
    {
        private readonly IMongoDatabase _database = null;

        public AppDbContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Book> Books
        {
            get
            {
                return _database.GetCollection<Book>("Book");
            }
        }

        public IMongoCollection<Author> Authors
        {
            get
            {
                return _database.GetCollection<Author>("Author");
            }
        }


    }
}
