using Net.Core.Mongo.PoC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net.Core.Mongo.PoC.Interfaces
{
    public interface IBookServices
    {
        List<Book> Get();
        Book Get(string isbn);
        Book Create(Book book);
        void Update(string isbn, Book bookIn);
        void Remove(Book bookIn);
        void Remove(string isbn);

    }
}
