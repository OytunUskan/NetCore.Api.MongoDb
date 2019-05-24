using Net.Core.Mongo.PoC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net.Core.Mongo.PoC.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBook(string isbn);

        // query after multiple parameters
        Task<IEnumerable<Book>> Getbook(string bookName);

        // add new book document
        Task AddBook(Book item);

        // remove a single document / book
        Task<bool> RemoveBook(string isbn);

        // update just a single document / book
        Task<bool> UpdateBook(string isbn, string bookName);
        Task<bool> UpdateBook(string isbn, Book book);

        // demo interface - full document update
        Task<bool> UpdateBookDocument(string isbn, string bookName);

        // should be used with high cautious, only in relation with demo setup
        Task<bool> RemoveAllBooks();

    }
}
