using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Net.Core.Mongo.PoC.Interfaces;
using Net.Core.Mongo.PoC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net.Core.Mongo.PoC.Services
{
    public class BookService : IBookServices
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("BookstoreDb"));
            var database = client.GetDatabase("BookstoreDb");
            _books = database.GetCollection<Book>("Books");
        }



        public List<Book> Get()
        {
            return _books.Find(book => true).ToList();
        }

        public Book Get(string isbn)
        {
            return _books.Find<Book>(book => book.ISBN == isbn).FirstOrDefault();
        }

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string isbn, Book bookIn)
        {
            _books.ReplaceOne(book => book.ISBN == isbn, bookIn);
        }

        public void Remove(Book bookIn)
        {
            _books.DeleteOne(book => book.Id == bookIn.Id);
        }

        public void Remove(string isbn)
        {
            _books.DeleteOne(book => book.ISBN == isbn);
        }


    }
}
