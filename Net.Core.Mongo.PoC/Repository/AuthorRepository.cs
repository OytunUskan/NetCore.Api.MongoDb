using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Net.Core.Mongo.PoC.Context;
using Net.Core.Mongo.PoC.Interfaces;
using Net.Core.Mongo.PoC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net.Core.Mongo.PoC.Repository
{
    public class AuthorRepository : IAuthorRepository
    {

        private readonly AppDbContext _context = null;

        public AuthorRepository(IOptions<Settings> settings)
        {
            _context = new AppDbContext(settings);
        }

        public async Task AddAuthor(Author item)
        {
            try
            {
                await _context.Authors.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            try
            {
                return await _context.Authors.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<Author> GetAuthor(int authorId)
        {
            try
            {
                return await _context.Authors
                                .Find(author => author.AuthorId == authorId)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public Author GetAuthorById(int authorId)
        {
            try
            {
                return  _context.Authors
                                .Find(author => author.AuthorId == authorId)
                                .FirstOrDefault();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveAllAuthors()
        {
            try
            {
                DeleteResult actionResult = await _context.Authors.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        //public async Task AddBook(Book item)
        //{
        //    try
        //    {
        //        await _context.Books.InsertOneAsync(item);
        //    }
        //    catch (Exception ex)
        //    {
        //        // log or manage the exception
        //        throw ex;
        //    }
        //}
        //public async Task<IEnumerable<Book>> GetAllBooks()
        //{
        //    try
        //    {
        //        return await _context.Books.Find(_ => true).ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        // log or manage the exception
        //        throw ex;
        //    }
        //}
        //public async Task<Book> GetBook(string isbn)
        //{
        //    try
        //    {
        //        return await _context.Books
        //                        .Find(book => book.ISBN == isbn)
        //                        .FirstOrDefaultAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        // log or manage the exception
        //        throw ex;
        //    }
        //}
        //public async Task<IEnumerable<Book>> Getbook(string bookName)
        //{
        //    try
        //    {
        //        var query = _context.Books.Find(book => book.BookName.Contains(bookName));

        //        return await query.ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        // log or manage the exception
        //        throw ex;
        //    }
        //}
        //public async Task<bool> RemoveAllBooks()
        //{
        //    try
        //    {
        //        DeleteResult actionResult  = await _context.Books.DeleteManyAsync(new BsonDocument());

        //        return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        // log or manage the exception
        //        throw ex;
        //    }
        //}
        //public async Task<bool> RemoveBook(string isbn)
        //{
        //    try
        //    {
        //        DeleteResult actionResult = await _context.Books.DeleteOneAsync(Builders<Book>.Filter.Eq("ISBN", isbn));

        //        return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        // log or manage the exception
        //        throw ex;
        //    }
        //}
        //public async Task<bool> UpdateBook(string isbn, string bookName)
        //{
        //    var filter = Builders<Book>.Filter.Eq(s => s.ISBN, isbn);
        //    var update = Builders<Book>.Update
        //                    .Set(s => s.BookName, bookName)
        //                    .CurrentDate(s => s.ModifiedDate);

        //    try
        //    {
        //        UpdateResult actionResult
        //            = await _context.Books.UpdateOneAsync(filter, update);

        //        return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        // log or manage the exception
        //        throw ex;
        //    }
        //}
        //public async Task<bool> UpdateBookDocument(string isbn, string bookName)
        //{
        //    var item = await GetBook(isbn) ?? new Book();
        //    item.BookName = bookName;
        //    item.CreatedDate = DateTime.Now;
        //    item.ModifiedDate = DateTime.Now;

        //    return await UpdateBook(isbn, item);
        //}


        //public async Task<bool> UpdateBook(string isbn, Book item)
        //{
        //    try
        //    {
        //        ReplaceOneResult actionResult
        //            = await _context.Books
        //                            .ReplaceOneAsync(n => n.ISBN.Equals(isbn)
        //                                    , item
        //                                    , new UpdateOptions { IsUpsert = true });
        //        return actionResult.IsAcknowledged
        //            && actionResult.ModifiedCount > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        // log or manage the exception
        //        throw ex;
        //    }
        //}

        //public Task<IEnumerable<Author>> GetAllAuthors() => throw new NotImplementedException();
        //public Task AddAuthor(Author item) => throw new NotImplementedException();
    }
}
