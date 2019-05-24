using Net.Core.Mongo.PoC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net.Core.Mongo.PoC.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthors();

        // add new author document
        Task AddAuthor(Author item);

        Task<Author> GetAuthor(int authorId);
        Author GetAuthorById(int authorId);

        Task<bool> RemoveAllAuthors();

    }
}
