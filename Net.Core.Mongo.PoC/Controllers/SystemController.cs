using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Net.Core.Mongo.PoC.Interfaces;
using Net.Core.Mongo.PoC.Models;

namespace Net.Core.Mongo.PoC.Controllers
{
    [Route("api/[controller]")]
    public class SystemController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public SystemController(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }



        [HttpGet("{setting}")]
        public string Get(string setting)
        {
            if(setting == "init")
            {


                _authorRepository.RemoveAllAuthors();
                _authorRepository.AddAuthor(new Author() {
                    AuthorId = 1,
                    Name = "Jules Verne",
                    Age = 48,
                    CreatedDate = DateTime.Now
                });

                _authorRepository.AddAuthor(new Author()
                {
                    AuthorId = 2,
                    Name = "Carl Sagan",
                    Age = 52,
                    CreatedDate = DateTime.Now
                });

                _authorRepository.AddAuthor(new Author()
                {
                    AuthorId = 3,
                    Name = "Stephen Hawking",
                    Age = 50,
                    CreatedDate = DateTime.Now
                });

                _bookRepository.RemoveAllBooks();
                _bookRepository.AddBook(new Book()
                {
                    ISBN = "123qwe123qwe",
                    BookName = "The Mysterious Island",
                    CreatedDate = DateTime.Now,
                    Price = Convert.ToDecimal("3.50"),
                    Author = _authorRepository.GetAuthorById(1)

                });

                _bookRepository.AddBook(new Book()
                {
                    ISBN = "456rty456rty",
                    BookName = "Cosmos",
                    CreatedDate = DateTime.Now,
                    Price = Convert.ToDecimal("4.00"),
                    Author = _authorRepository.GetAuthorById(2)

                });


                _bookRepository.AddBook(new Book()
                {
                    ISBN = "789uop789uop",
                    BookName = "Black Holes",
                    CreatedDate = DateTime.Now,
                    Price = Convert.ToDecimal("5.00"),
                    Author = _authorRepository.GetAuthorById(3)

                });
                return "Database BookStoreDb was created, and collection 'Books and Authors' were filled with 3 sample items";
            }

            return "Unknown";

        }





        }
}